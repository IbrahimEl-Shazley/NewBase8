﻿namespace NewBase.Services.ServiceHelpers.EmailTemplates
{
    public interface INotificationTemplate
    {
        public string Prepare(string htmlTemplate, dynamic input);
    }
}