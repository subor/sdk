#pragma once

#include "thrift/TBase.h"

using namespace std;
using namespace apache::thrift;

#ifndef REGIST_CREATION_FUNCTION

typedef TBase* (*MessageCreatorFunc)();

#define REGIST_CREATION_FUNCTION(msgName, msgType) \
	{\
		MessageCreator::Register<msgType>(msgName);\
	}

template<class T>
TBase* CreateMessagePtr()
{
	return dynamic_cast<TBase*>(new T());
}
#endif

namespace Ruyi
{
	class MessageCreator
	{
	public:
		static TBase* CreateMessage(string mt)
		{
			std::map<string, MessageCreatorFunc>::iterator itr = ccs.find(mt);
			if (itr == ccs.end())
				return NULL;

			MessageCreatorFunc mcf = itr->second;
			return mcf();
		}

		template<class T>
		static void Register(string name)
		{
			MessageCreatorFunc p = &CreateMessagePtr<T>;
			ccs.insert(std::make_pair(name, p));
		}

	private:
		static void Initialize();

		static std::map<string, MessageCreatorFunc> ccs;
	};
}
