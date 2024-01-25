﻿namespace chattech_users.Enums
{
    public enum HttpStatusCode
    {
        OK = 200,
        Created = 201,
        Accepted = 202,
        NoContent = 204,

        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        MethodNotAllowed = 405,
        Conflict = 409,
        Gone = 410,

        InternalServerError = 500,
        NotImplemented = 501,
        BadGateway = 502,
        ServiceUnavailable = 503,
        GatewayTimeout = 504
    }
}
