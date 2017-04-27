namespace FileCompare.Interfaces
{
    public interface IMainFormView
    {
        UCFileView LeftFileView { get; }
        UCFileView RightFileView { get; }
        FooterInfoBar Footer { get; }
    }
}