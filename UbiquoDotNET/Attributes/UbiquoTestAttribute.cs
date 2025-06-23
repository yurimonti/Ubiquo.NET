using UbiquoDotNET.Abstractions;

namespace UbiquoDotNET.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    internal class UbiquoTestAttribute : Attribute
    {
        public string TestName { get; set; }
        public IMockBehavior MockBehavior { get; set; }
        public UbiquoTestAttribute(string testName, IMockBehavior mockBehavior) 
        {
            TestName = testName;
            MockBehavior = mockBehavior;

        }
    }
}
