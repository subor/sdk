#pragma once

#include <string>

#include "boost/thread.hpp"

#include "thrift/TBase.h"
#include "thrift/protocol/TBinaryProtocol.h"

using namespace std;
using namespace apache::thrift;
using namespace apache::thrift::protocol;

///<summary>
/// MessageHandler<void, std::string, apache::thrift::TBase*>* mh1 = new MessageHandler<void, std::string, apache::thrift::TBase*>();
///	mh->AddHandler(OnFileUploadSuccess);
/// mh->AddHanderl(pointer, &XXXClassName::OnFileUploadSuccess);
///	sdkSubscriber->AddMessageHandler(mh);
///<summary/>
template<typename R = void, typename... Args>
class MessageHandler
{
private:
	std::list<std::function<R(Args...)> > _calls;

public:
	virtual ~MessageHandler()
	{
		_calls.clear();
	}

	void AddHandler(std::function<R(Args...)> handler)
	{
		_calls.push_back(handler);
	}

	template<typename Object>
	void AddHandler(Object* object, R(Object::*method)(Args...))
	{
		_calls.push_back([object, method](Args... args) {(*object.*method)(args...); });
	}

	template<typename Object>
	void AddHandler(Object* object, R(Object::*method)(Args...) const)
	{
		_calls.push_back([object, method](Args... args) {(*object.*method)(args...); });
	}

	template<typename Object>
	void AddHandler(const Object* object, R(Object::*method)(Args...) const)
	{
		_calls.push_back([object, method](Args... args) {(*object.*method)(args..); });
	}

	void listen(Args... args)
	{
		for (auto call : _calls)
		{
			call(args...);
		}
	}
};

namespace zmq
{
	class socket_t;
	class context_t;
}

namespace Ruyi
{
	namespace SDK
	{
		class SubscribeClient
		{
		public:
			static SubscribeClient* CreateInstance(string serverUri);

			~SubscribeClient();

			void Subscribe(string topic);
			void Unsubscribe(string topic);
			
			void RemoveMessageHandler(int handlerKey);

			template<typename R = void, typename Object>
			int AddMessageHandler(Object* object, R(Object::*method)(string, TBase*))
			{
				MessageHandler<void, std::string, apache::thrift::TBase*>* mh = new MessageHandler<void, std::string, apache::thrift::TBase*>();

				mh->AddHandler(object, method);

				handlers[++handlerKey] = mh;

				return handlerKey;
			}

			int AddMessageHandler(void(*method)(string, TBase*));

			void Dispose();

		private:
			string serverUri;
			zmq::socket_t* subscriber;
			zmq::context_t* context;

			std::shared_ptr<boost::thread> receivingThread;
			//boost::shared_ptr<boost::thread> receivingThread;

			vector<string> topics;

			int handlerKey;
			std::map<int, MessageHandler<void, string, TBase*>*> handlers;

		private:
			SubscribeClient();

			void Receive();

			bool ContainsTopic(string topic);
		};
	}
}
