namespace Reflection2
{
    internal class TestClass
    {
        [CustomName("CustomFieldName")]
        public int I { get; set; }
        [CustomName("AnotherCustomFieldName")]
        public string? S { get; set; }
        public decimal D { get; set; }
        public char[]? C { get; set; }

        public TestClass() { }
        
        private TestClass(int i)
        {
            this.I = i;
        }

        public TestClass(int i, string s, decimal d, char[] c) : this(i)
        {
            this.S = s;
            this.D = d;
            this.C = c;
        }
    }
}

