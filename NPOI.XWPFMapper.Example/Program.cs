using NPOI.XWPF.UserModel;
using NPOI.XWPFMapper.Enums;
using NPOI.XWPFMapper.Example;
using NPOI.XWPFMapper.Managers;

XWPFDocument document = new XWPFDocument();

ExampleClass exampleData = new ExampleClass()
{
    Enum = ExampleEnum.Red,
    Name = "This is a test",
    IgnoredMember = "This member will be ignored",
    Address = new ExampleChildClass()
    {
        Address = "Burgemeester Schönfeldplein",
        City = "Winschoten",
        CountryCode = "NL"
    }
};

// XWPFTableWrapper requires a Type argument and an XWPFDocument object to work
// In addition you can optionally set the direction of the table with an enum XWPFTableAlignment (default is Row)

XWPFTableWrapper<ExampleClass> wrapper = new XWPFTableWrapper<ExampleClass>(document, XWPFTableAlignment.Column);
wrapper.Insert(exampleData);

using FileStream fs = new FileStream("test.docx", FileMode.Create);
document.Write(fs);