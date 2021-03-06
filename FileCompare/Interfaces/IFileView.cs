﻿using System;
using System.Windows.Forms;
using FileCompare.Presenters;

namespace FileCompare.Interfaces
{
    public interface IFileView
    {
        string FileNameAndPath { set; }
        Panel TextPanelControl { get; }

        FileViewPresenter Presenter { set; }
        ToolStripButton OpenFile { get; }
        event EventHandler LoadFileClicked;
    }
}