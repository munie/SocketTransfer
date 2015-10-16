﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Net.Sockets;

namespace EnvModule
{
    public enum SockState
	{
        //None = 0,
        Opening = 1,
        Closing = 2,
        Opened = 3,
        Closed = 4,
	}

    public class ModuleUnit : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string ID { get; set; }
        public string Name { get; set; }
        public UInt16 Type { get; set; }

        public Socket Sock { get; set; }
        private SockState state;
        public byte[] SendBuff { get; set; }
        public int SendBuffSize { get; set; }

        public string FilePath { get; set; }
        private string fileName;
        private string fileComment;

        public SockState State
        {
            get { return state; }
            set
            {
                state = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("State"));
            }
        }
        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("FileName"));
            }
        }
        public string FileComment
        {
            get { return fileComment; }
            set
            {
                fileComment = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("FileComment"));
            }
        }

        public Mnn.MnnMisc.MnnModule.ModuleItem Module { get; set; }
    }
}