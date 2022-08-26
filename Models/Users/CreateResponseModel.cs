﻿namespace RestApiMyTasks.Models.Users
{
    public class CreateResponseModel
    {
        public CreateResponseModel (int? statusCode, int? createdBit, string? msg)
        {
            this.statusCode = statusCode;
            this.createdBit = createdBit;
            this.msg = msg;
        }

        public int? statusCode { get; set; }
        public int? createdBit { get; set; }
        public string? msg { get; set; }
    }
}
