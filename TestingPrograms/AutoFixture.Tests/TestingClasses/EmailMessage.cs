namespace TestingPrograms.AutoFixture.Tests.TestingClasses
{
    public class EmailMessage
    {
        private readonly string _somePrivateField;

        public string SomePublicField;

        public EmailMessage(string toAddress, string messageBody, bool isImportant)
        {
            ToAddress = toAddress;
            MessageBody = messageBody;
            IsImportant = isImportant;
            SomePublicField = string.Empty;
            SomePrivateProperty = string.Empty;
            Subject = string.Empty;
            _somePrivateField = "test";
        }

        private string SomePrivateProperty { get; }
        public Guid Id { get; set; }
        public string ToAddress { get; set; }
        public string MessageBody { get; }
        public string Subject { get; set; }
        public bool IsImportant { get; set; }

        public EmailMessageType MessageType { get; set; }

        public string GetSomePrivateProperty()
        {
            return SomePrivateProperty;
        }

        public string GetSomePrivateField()
        {
            return _somePrivateField;
        }
    }

    public enum EmailMessageType
    {
        Unspecified,
        Sales,
        Support,
        AccountManagement
    }
}