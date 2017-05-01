using System;
using System.Drawing;

namespace FileCompare.Presenters
{
    public class FooterViewPresenter
    {
        private FooterInfoBar _footer;

        public FooterViewPresenter(FooterInfoBar footer)
        {
            _footer = footer;
            footer.Presenter = this;
            _footer.Load += footerInfoBar_Load;
            _footer.SizeChanged += PositionRightLabels;
        }

        private void footerInfoBar_Load(object sender, EventArgs e)
        {
            ResetLabelText();
            PositionRightLabels(sender, e);
        }

        private void PositionRightLabels(object sender, EventArgs e)
        {
            var width = _footer.Size.Width;
            var sizeLabel = _footer.Controls["FileSizeRight"];
            var sizeText = _footer.Controls["lblRightFileSize"];
            sizeLabel.Location = new Point(width / 2, sizeLabel.Location.Y);
            sizeText.Location = new Point(width / 2 + sizeLabel.Size.Width, sizeText.Location.Y);

            var modDateLabel = _footer.Controls["FileModDateRight"];
            var modDate = _footer.Controls["lblRightFileModDate"];
            modDateLabel.Location = new Point(sizeText.Location.X + sizeText.Size.Width + 5, modDateLabel.Location.Y);
            modDate.Location = new Point(modDateLabel.Location.X + modDateLabel.Size.Width, modDate.Location.Y);

            var createDateLabel = _footer.Controls["FileCreateDateRight"];
            var createDate = _footer.Controls["lblRightFileCreateDate"];
            createDateLabel.Location = new Point(sizeText.Location.X + sizeText.Size.Width + 5, createDateLabel.Location.Y);
            createDate.Location = new Point(createDateLabel.Location.X + createDateLabel.Size.Width, createDate.Location.Y);
        }

        private void ResetLabelText()
        {
            _footer.LeftFileSizeLabel = string.Empty;
            _footer.LeftFileCreatedDateLabel = string.Empty;
            _footer.LeftFileModifiedDateLabel = string.Empty;
            _footer.RightFileSizeLabel = string.Empty;
            _footer.RightFileCreatedDateLabel = string.Empty;
            _footer.RightFileModifiedDateLabel = string.Empty;
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            var leftPanelText = _footer.GetContainerControl();
        }
    }
}