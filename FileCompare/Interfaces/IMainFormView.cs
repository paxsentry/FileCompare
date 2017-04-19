using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCompare.Interfaces
{
    public interface IMainFormView
    {
        IFileView LeftFileView { get; }
        IFileView RightFileView { get; }
    }
}
