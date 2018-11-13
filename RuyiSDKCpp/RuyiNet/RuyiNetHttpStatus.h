#pragma once

namespace Ruyi { namespace SDK { namespace Online {
	/// <summary>
	/// Status codes returned from RuyiNet operations.
	/// </summary>
	class RuyiNetHttpStatus 
	{
	public:
		/// <summary>
		/// This interim response indicates that everything so far is OK and that the
		/// client should continue with the request or ignore it if it is already
		/// finished.
		/// </summary>
		static const int CONTINUE = 100;

		/// <summary>
		/// This code is sent in response to an Upgrade request header by the client,
		/// and indicates the protocol the server is switching to.
		/// </summary>
		static const int SWITCHING_PROTOCOLS = 101;

		/// <summary>
		/// This code indicates that the server has received and is processing the
		/// request, but no response is available yet.
		/// </summary>
		static const int PROCESSING = 102;

		/// <summary>
		/// The request succeeded.
		/// </summary>
		static const int OK = 200;

		/// <summary>
		/// The request has succeeded and a new resource has been created as a result of
		/// it.
		/// </summary>
		static const int CREATED = 201;

		/// <summary>
		/// The request has been received but not yet acted upon.
		/// </summary>
		static const int ACCEPTED = 202;

		/// <summary>
		/// This response code means returned meta-information set is not exact set as
		/// available from the origin server, but collected from a local or a third
		/// party copy.
		/// </summary>
		static const int NON_AUTHORITATIVE_INFORMATION = 203;

		/// <summary>
		/// There is no content to send for this request, but the headers may be useful.
		/// </summary>
		static const int NO_CONTENT = 204;

		/// <summary>
		/// This response code is sent after accomplishing request to tell user agent
		/// reset document view which sent this request.
		/// </summary>
		static const int RESET_CONTENT = 205;

		/// <summary>
		/// This response code is used because of range header sent by the client to
		/// separate download into multiple streams.
		/// </summary>
		static const int PARTIAL_CONTENT = 206;

		/// <summary>
		/// A Multi-Status response conveys information about multiple resources in
		/// situations where multiple status codes might be appropriate.
		/// </summary>
		static const int MULTI_STATUS = 207;

		/// <summary>
		/// Used inside a DAV: propstat response element to avoid enumerating the
		/// internal members of multiple bindings to the same collection repeatedly.
		/// </summary>
		static const int ALREADY_REPORTED = 208;

		/// <summary>
		/// The server has fulfilled a GET request for the resource, and the response is
		/// a representation of the result of one or more instance-manipulations applied
		/// to the current instance.
		/// </summary>
		static const int IM_USED = 226;

		/// <summary>
		/// The request has more than one possible response. The user-agent or user
		/// should choose one of them. There is no standardized way of choosing one of
		/// the responses.
		/// </summary>
		static const int MULTIPLE_CHOICES = 300;

		/// <summary>
		/// This response code means that the URI of the requested resource has been
		/// changed. Probably, the new URI would be given in the response.
		/// </summary>
		static const int MOVED_PERMANENTLY = 301;

		/// <summary>
		/// This response code means that the URI of requested resource has been changed
		/// temporarily. New changes in the URI might be made in the future. Therefore,
		/// this same URI should be used by the client in future requests.
		/// </summary>
		static const int FOUND = 302;

		/// <summary>
		/// The server sent this response to direct the client to get the requested
		/// resource at another URI with a GET request.
		/// </summary>
		static const int SEE_OTHER = 303;

		/// <summary>
		/// This is used for caching purposes. It tells the client that the response has
		/// not been modified, so the client can continue to use the same cached version
		/// of the response.
		/// </summary>
		static const int NOT_MODIFIED = 304;

		/// <summary>
		/// Was defined in a previous version of the HTTP specification to indicate that
		/// a requested response must be accessed by a proxy. It has been deprecated due
		/// to security concerns regarding in-band configuration of a proxy.
		/// </summary>
		static const int USE_PROXY = 305;

		/// <summary>
		/// The server sends this response to direct the client to get the requested
		/// resource at another URI with same method that was used in the prior request.
		/// This has the same semantics as the 302 Found HTTP response code, with the
		/// exception that the user agent must not change the HTTP method used: If a
		/// POST was used in the first request, a POST must be used in the second
		/// request.
		/// </summary>
		static const int TEMPORARY_REDIRECT = 307;

		/// <summary>
		/// This means that the resource is now permanently located at another URI,
		/// specified by the Location: HTTP Response header. This has the same semantics
		/// as the 301 Moved Permanently HTTP response code, with the exception that the
		/// user agent must not change the HTTP method used: If a POST was used in the
		/// first request, a POST must be used in the second request.
		/// </summary>
		static const int PERMANENT_REDIRECT = 308;

		/// <summary>
		/// This response means that server could not understand the request due to
		/// invalid syntax.
		/// </summary>
		static const int BAD_REQUEST = 400;

		/// <summary>
		/// Although the HTTP standard specifies "unauthorized", semantically this
		/// response means "unauthenticated". That is, the client must authenticate
		/// itself to get the requested response.
		/// </summary>
		static const int UNAUTHORIZED = 401;

		/// <summary>
		/// This response code is reserved for future use. Initial aim for creating this
		/// code was using it for digital payment systems however this is not used
		/// currently.
		/// </summary>
		static const int PAYMENT_REQUIRED = 402;

		/// <summary>
		/// The client does not have access rights to the content, i.e. they are
		/// unauthorized, so server is rejecting to give proper response. Unlike 401,
		/// the client's identity is known to the server.
		/// </summary>
		static const int FORBIDDEN = 403;

		/// <summary>
		/// The server can not find requested resource. In the browser, this means the
		/// URL is not recognized. In an API, this can also mean that the endpoint is
		/// valid but the resource itself does not exist. Servers may also send this
		/// response instead of 403 to hide the existence of a resource from an
		/// unauthorized client. This response code is probably the most famous one due
		/// to its frequent occurence on the web.
		/// </summary>
		static const int NOT_FOUND = 404;

		/// <summary>
		/// The request method is known by the server but has been disabled and cannot
		/// be used. For example, an API may forbid DELETE-ing a resource. The two
		/// mandatory methods, GET and HEAD, must never be disabled and should not
		/// return this error code.
		/// </summary>
		static const int METHOD_NOT_ALLOWED = 405;

		/// <summary>
		/// This response is sent when the web server, after performing server-driven
		/// content negotiation, doesn't find any content following the criteria given
		/// by the user agent.
		/// </summary>
		static const int NOT_ACCEPTABLE = 406;

		/// <summary>
		/// This is similar to 401 but authentication is needed to be done by a proxy.
		/// </summary>
		static const int PROXY_AUTHENTICATION_REQUIRED = 407;

		/// <summary>
		/// This response is sent on an idle connection by some servers, even without
		/// any previous request by the client. It means that the server would like to
		/// shut down this unused connection. This response is used much more since some
		/// browsers, like Chrome, Firefox 27+, or IE9, use HTTP pre-connection
		/// mechanisms to speed up surfing. Also note that some servers merely shut down
		/// the connection without sending this message.
		/// </summary>
		static const int REQUEST_TIMEOUT = 408;

		/// <summary>
		/// This response is sent when a request conflicts with the current state of the
		/// server.
		/// </summary>
		static const int CONFLICT = 409;

		/// <summary>
		/// This response would be sent when the requested content has been permenantly
		/// deleted from server, with no forwarding address. Clients are expected to
		/// remove their caches and links to the resource. The HTTP specification
		/// intends this status code to be used for "limited-time, promotional
		/// services". APIs should not feel compelled to indicate resources that have
		/// been deleted with this status code.
		/// </summary>
		static const int GONE = 410;

		/// <summary>
		/// Server rejected the request because the Content-Length header field is not
		/// defined and the server requires it.
		/// </summary>
		static const int LENGTH_REQUIRED = 411;

		/// <summary>
		/// The client has indicated preconditions in its headers which the server does
		/// not meet.
		/// </summary>
		static const int PRECONDITION_FAILED = 412;

		/// <summary>
		/// Request entity is larger than limits defined by server; the server might
		/// close the connection or return an Retry-After header field.
		/// </summary>
		static const int PAYLOAD_TOO_LARGE = 413;

		/// <summary>
		/// The URI requested by the client is longer than the server is willing to
		/// interpret.
		/// </summary>
		static const int REQUEST_URI_TOO_LONG = 414;

		/// <summary>
		/// The media format of the requested data is not supported by the server, so
		/// the server is rejecting the request.
		/// </summary>
		static const int UNSUPPORTED_MEDIA_TYPE = 415;

		/// <summary>
		/// The range specified by the Range header field in the request can't be
		/// fulfilled; it's possible that the range is outside the size of the target
		/// URI's data.
		/// </summary>
		static const int REQUESTED_RANGE_NOT_SATISFIABLE = 416;

		/// <summary>
		/// This response code means the expectation indicated by the Expect request
		/// header field can't be met by the server.
		/// </summary>
		static const int EXPECTATION_FAILED = 417;

		/// <summary>
		/// The server refuses the attempt to brew coffee with a teapot.
		/// </summary>
		static const int IM_A_TEAPOT = 418;

		/// <summary>
		/// The request was directed at a server that is not able to produce a response.
		/// This can be sent by a server that is not configured to produce responses for
		/// the combination of scheme and authority that are included in the request
		/// URI.
		/// </summary>
		static const int MISDIRECTED_REQUEST = 421;

		/// <summary>
		/// The request was well-formed but was unable to be followed due to semantic
		/// errors.
		/// </summary>
		static const int UNPROCESSABLE_ENTITY = 422;

		/// <summary>
		/// The resource that is being accessed is locked.
		/// </summary>
		static const int LOCKED = 423;

		/// <summary>
		/// The request failed due to failure of a previous request.
		/// </summary>
		static const int FAILED_DEPENDENCY = 424;

		/// <summary>
		/// The server refuses to perform the request using the current protocol but
		/// might be willing to do so after the client upgrades to a different protocol.
		/// The server sends an Upgrade header in a 426 response to indicate the
		/// required protocol(s).
		/// </summary>
		static const int UPGRADE_REQUIRED = 426;

		/// <summary>
		/// The origin server requires the request to be conditional. Intended to
		/// prevent the 'lost update' problem, where a client GETs a resource's state,
		/// modifies it, and PUTs it back to the server, when meanwhile a third party
		/// has modified the state on the server, leading to a conflict.
		/// </summary>
		static const int PRECONDITION_REQUIRED = 428;

		/// <summary>
		/// The user has sent too many requests in a given amount of time ("rate
		/// limiting").
		/// </summary>
		static const int TOO_MANY_REQUESTS = 429;

		/// <summary>
		/// The server is unwilling to process the request because its header fields are
		/// too large. The request MAY be resubmitted after reducing the size of the
		/// request header fields.
		/// </summary>
		static const int REQUEST_HEADER_FIELDS_TOO_LARGE = 431;

		/// <summary>
		/// 
		/// </summary>
		static const int CONNECTION_CLOSED_WITHOUT_RESPONSE = 444;

		/// <summary>
		/// The user requests an illegal resource, such as a web page censored by a
		/// government.
		/// </summary>
		static const int UNAVAILABLE_FOR_LEGAL_REASONS = 451;

		/// <summary>
		/// 
		/// </summary>
		static const int CLIENT_CLOSED_REQUEST = 499;

		/// <summary>
		/// The server has encountered a situation it doesn't know how to handle.
		/// </summary>
		static const int INTERNAL_SERVER_ERROR = 500;

		/// <summary>
		/// The request method is not supported by the server and cannot be handled. The
		/// only methods that servers are required to support (and therefore that must
		/// not return this code) are GET and HEAD.
		/// </summary>
		static const int NOT_IMPLEMENTED = 501;

		/// <summary>
		/// This error response means that the server, while working as a gateway to get
		/// a response needed to handle the request, got an invalid response.
		/// </summary>
		static const int BAD_GATEWAY = 502;

		/// <summary>
		/// The server is not ready to handle the request. Common causes are a server
		/// that is down for maintenance or that is overloaded. Note that together with
		/// this response, a user-friendly page explaining the problem should be sent.
		/// This responses should be used for temporary conditions and the Retry-After:
		/// HTTP header should, if possible, contain the estimated time before the
		/// recovery of the service. The webmaster must also take care about the
		/// caching-related headers that are sent along with this response, as these
		/// temporary condition responses should usually not be cached.
		/// </summary>
		static const int SERVICE_UNAVAILABLE = 503;

		/// <summary>
		/// This error response is given when the server is acting as a gateway and
		/// cannot get a response in time.
		/// </summary>
		static const int GATEWAY_TIMEOUT = 504;

		/// <summary>
		/// The HTTP version used in the request is not supported by the server.
		/// </summary>
		static const int HTTP_VERSION_NOT_SUPPORTED = 505;

		/// <summary>
		/// The server has an internal configuration error: transparent content
		/// negotiation for the request results in a circular reference.
		/// </summary>
		static const int VARIANT_ALSO_NEGOTIATES = 506;

		/// <summary>
		/// The server has an internal configuration error: the chosen variant resource
		/// is configured to engage in transparent content negotiation itself, and is
		/// therefore not a proper end point in the negotiation process.
		/// </summary>
		static const int INSUFFICIENT_STORAGE = 507;

		/// <summary>
		/// The server detected an infinite loop while processing the request.
		/// </summary>
		static const int LOOP_DETECTED = 508;

		/// <summary>
		/// Further extensions to the request are required for the server to fulfill it.
		/// </summary>
		static const int NOT_EXTENDED = 510;

		/// <summary>
		/// The 511 status code indicates that the client needs to authenticate to gain
		/// network access.
		/// </summary>
		static const int NETWORK_AUTHENTICATION_REQUIRED = 511;

		/// <summary>
		/// 
		/// </summary>
		static const int NETWORK_CONNECT_TIMEOUT_ERROR = 599;
	};
}}} //namespace