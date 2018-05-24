#include "SubscribeClient.h"
#include "zmq.hpp"
#include "MessageCreator.h"

#include "../RuyiSDK.h"

#include "thrift/transport/TBufferTransports.h"

using namespace Ruyi::SDK;
using namespace zmq;

using namespace apache::thrift;

SubscribeClient* SubscribeClient::CreateInstance(string serverUri)
{
	SubscribeClient* ret = new SubscribeClient();
	ret->context = new context_t(1);

	ret->subscriber = new socket_t(*ret->context, ZMQ_SUB);
	ret->subscriber->connect(serverUri);

	return ret;
}

SubscribeClient::SubscribeClient()
	:subscriber(NULL), serverUri("localhost"), receivingThread(NULL)
{
	handlerKey = 0;
}


SubscribeClient::~SubscribeClient()
{
	if (subscriber != NULL)
	{
		delete subscriber;
		subscriber = NULL;
	}
	if (context != NULL)
	{
		delete context;
		context = NULL;
	}
}

void SubscribeClient::Subscribe(string topic)
{
	if (subscriber == NULL || ContainsTopic(topic))
		return;

	topics.push_back(topic);
	const char* filter = topic.c_str();
	subscriber->setsockopt(ZMQ_SUBSCRIBE, filter, strlen(filter));
	if (topics.size() > 0 && receivingThread == NULL)
	{
		receivingThread = std::make_shared<boost::thread>(boost::bind(&SubscribeClient::Receive, this));
	}
}

void SubscribeClient::Unsubscribe(string topic)
{
	if (subscriber == NULL || !ContainsTopic(topic))
		return;

	topics.erase(std::remove(topics.begin(), topics.end(), topic), topics.end());
	const char* filter = topic.c_str();
	subscriber->setsockopt(ZMQ_UNSUBSCRIBE, filter, strlen(filter));
}
/*
template<typename R, typename Object>
int SubscribeClient::AddMessageHandler(Object* object, R(Object::*method)(string, TBase*))
{
	MessageHandler<void, std::string, apache::thrift::TBase*>* mh = new MessageHandler<void, std::string, apache::thrift::TBase*>();

	mh->AddHandler(object, method);

	//handlers.push_back(mh);
	handlers[++handlerKey] = mh;

	return handlerKey;
}*/

int SubscribeClient::AddMessageHandler(void(*method)(string, TBase*))
{
	MessageHandler<void, std::string, apache::thrift::TBase*>* mh = new MessageHandler<void, std::string, apache::thrift::TBase*>();

	mh->AddHandler(method);

	handlers[++handlerKey] = mh;

	return handlerKey;
}

/*
void SubscribeClient::AddMessageHandler(MessageHandler<void, string, TBase*>* mh)
{
	for (auto itr = handlers.begin(); itr != handlers.end(); itr++)
	{
		if (*itr == mh)
			return;
	}
	handlers.push_back(mh);
}*/

/*
void SubscribeClient::RemoveMessageHandler(MessageHandler<void, string, TBase*>* mh)
{
	auto itr = std::find(handlers.begin(), handlers.end(), mh);
	if (itr != handlers.end())
		handlers.erase(itr);
}*/

void SubscribeClient::RemoveMessageHandler(int handlerKey)
{
	std::map<int, MessageHandler<void, string, TBase*>*>::iterator it = handlers.find(handlerKey);
	if (it != handlers.end()) 
	{
		delete it->second;
		handlers.erase(it);
	}
}

bool SubscribeClient::ContainsTopic(string topic)
{
	for (auto itr = topics.begin(); itr != topics.end(); itr++)
	{
		if (*itr == topic)
			return true;
	}
	return false;
}

void SubscribeClient::Receive()
{
	while (true)
	{
		// get the topic in 1st frame.
		char topicchar[256];
		size_t len = subscriber->recv(topicchar, 256);
		if (len <= 0)
			continue;
		string topic(topicchar, len);

		int more = 0;
		size_t moreSize = sizeof(more);

		// get the message type in 2nd frame.
		char type[512];
		subscriber->getsockopt(ZMQ_RCVMORE, &more, &moreSize);
		if (more <= 0)
			continue;
		len = subscriber->recv(type, 512);
		string msgType(type, len);

		// get the message content in 3rd frame.
		subscriber->getsockopt(ZMQ_RCVMORE, &more, &moreSize);
		if (more <= 0)
			continue;
		message_t msg;
		subscriber->recv(&msg);

		auto mb = std::make_shared<transport::TMemoryBuffer>(static_cast<uint8_t*>(msg.data()), (uint32_t)msg.size());
		protocol::TBinaryProtocol bp(mb);

		TBase* submsg = MessageCreator::CreateMessage(msgType);
		if (submsg != NULL)
		{
			submsg->read(&bp);
			
			/*
			for (int i = 0; i < handlers.size(); i++)
			{
				//(*handlers[i])(topic, submsg);
				handlers[i]->listen(topic, submsg);
			}*/

			for (std::map<int, MessageHandler<void, string, TBase*>*>::iterator it = handlers.begin(); it != handlers.end(); ++it)
			{
				it->second->listen(topic, submsg);
			}

			delete submsg;
		}
	}
}

void SubscribeClient::Dispose()
{
	if (receivingThread != NULL)
	{
		try {
			receivingThread->interrupt();
			receivingThread->join();
		}
		catch (exception e)
		{
		}
	}
}
