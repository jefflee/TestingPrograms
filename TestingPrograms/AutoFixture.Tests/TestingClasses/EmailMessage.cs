namespace TestingPrograms.AutoFixture.Tests.TestingClasses
{
    public class EmailMessage
    {
        private string _somePrivateField;

        public string SomePublicField;
        private string SomePrivateProperty { get; set; }
        public Guid Id { get; set; }
        public string ToAddress { get; set; }
        public string MessageBody { get; private set; }
        public string Subject { get; set; }
        public bool IsImportant { get; set; }

        public EmailMessageType MessageType { get; set; }

        public EmailMessage(string toAddress, string messageBody, bool isImportant)
        {
            ToAddress = toAddress;
            MessageBody = messageBody;
            IsImportant = isImportant;
            _somePrivateField = "test";
        }

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
