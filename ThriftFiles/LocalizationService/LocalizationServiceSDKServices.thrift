include "LocalizationServiceSDKDataTypes.thrift"

namespace * Ruyi.SDK.LocalizationService


service LocalizationService {
	/** Switch language to specified one. */
	bool SwitchLanguage(
		/** Which language to switch to. Should be the name of language code. Eg. en-US, zh-CN */
		1: string language, 
		
		/** Whether or not to load all context of the language */
		2: bool loadAllContext, 
		
		/** Whether or not to remove old language */
		3: bool removeOld
	),

	/** Get currently active language */
	string GetCurrentLanguage(),

	/** Switch a context of the language. */
	bool SwitchContext(
		/** Which context to switch to. */
		1: string context, 
		
		/** Which language that the context belong to */
		2: string language
	),

	/** Get currently active context. */
	string HintContext(),

	/** Get a localization string.
Return: localization string. */
	string GetString(
		/** The key of the string */
		1: string key, 
		
		/** The context that the string belong to. Null indicate find the first matching string throughout all contexts in the language. */
		2: string context, 
		
		/** The language to search */
		3: string language
	),

	/** Get a set of localization string. */
	map<string, string> GetStrings(
		/** A regular expresion used to filter the strings */
		1: string filter, 
		
		/** The context that the string belong to. Null indicate find the first matching string throughout all contexts in the language. */
		2: string context, 
		
		/** The language to search */
		3: string language
	),

	/** Get the file name/path in the language.

The search will go through the context and its sub context to find the file name. Eg. If file name is not found in context com.ruyi, then the search will go on to find it in com.ruyi.moduleA and com.ruyi.moduleB. */
	string GetFileName(
		/** File name with the path to the language pack root. */
		1: string filename, 
		
		/** True to get the virtual path, false to get the exact path to the file. */
		2: bool isVirtualPath, 
		
		/** The context of the file. If null, then while use system context "com.ruyi" */
		3: string context
	),
}

