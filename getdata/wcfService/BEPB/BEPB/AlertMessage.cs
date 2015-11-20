namespace BEPB
{
    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Windows.Media;

    public class AlertMessage : INotifyPropertyChanged
    {
        private SolidColorBrush _AlertLevelBackColor;
        private SolidColorBrush _AlertLevelForeColor;
        private string _Date_Time;
        private string _MContent;
        private string _Title;

        public event PropertyChangedEventHandler PropertyChanged;

        public AlertMessage()
        {
        }

        public AlertMessage(string Title, string PublishDate, string Content)
        {
            this.Title = Title;
            this.Date_Time = PublishDate;
            this.MContent = Content;
        }

        public SolidColorBrush AlertLevelBackColor
        {
            get
            {
                return this._AlertLevelBackColor;
            }
            set
            {
                this._AlertLevelBackColor = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("AlertLevelBackColor"));
                }
            }
        }

        public SolidColorBrush AlertLevelForeColor
        {
            get
            {
                return this._AlertLevelForeColor;
            }
            set
            {
                this._AlertLevelForeColor = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("AlertLevelForeColor"));
                }
            }
        }

        public string Date_Time
        {
            get
            {
                return this._Date_Time;
            }
            set
            {
                this._Date_Time = "发布时间：" + value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Date_Time"));
                }
            }
        }

        public string MContent
        {
            get
            {
                return this._MContent;
            }
            set
            {
                this._MContent = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("MContent"));
                }
            }
        }

        public string Title
        {
            get
            {
                return this._Title;
            }
            set
            {
                this._Title = value;
                string str = this._Title;
                if (str != null)
                {
                    if (!(str == "空气重污染蓝色预警"))
                    {
                        if (str == "空气重污染黄色预警")
                        {
                            this.AlertLevelBackColor = new SolidColorBrush(Colors.get_Yellow());
                            this.AlertLevelForeColor = new SolidColorBrush(Colors.get_Black());
                        }
                        else if (str == "空气重污染橙色预警")
                        {
                            this.AlertLevelBackColor = new SolidColorBrush(Colors.get_Orange());
                            this.AlertLevelForeColor = new SolidColorBrush(Colors.get_Black());
                        }
                        else if (str == "空气重污染红色预警")
                        {
                            this.AlertLevelBackColor = new SolidColorBrush(Colors.get_Red());
                            this.AlertLevelForeColor = new SolidColorBrush(Colors.get_White());
                        }
                    }
                    else
                    {
                        this.AlertLevelBackColor = new SolidColorBrush(Colors.get_Blue());
                        this.AlertLevelForeColor = new SolidColorBrush(Colors.get_White());
                    }
                }
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Title"));
                }
            }
        }
    }
}

