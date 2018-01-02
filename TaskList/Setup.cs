using System;
using System.Collections.Generic;
using System.Text;

namespace TaskList
{
    public static class Setup
    {
        public static void Configure()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Console.InputEncoding = Encoding.GetEncoding(852);
            Console.OutputEncoding = Encoding.UTF8;
        }
    }
}
