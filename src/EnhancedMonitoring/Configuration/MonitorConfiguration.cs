//The MIT License (MIT)
//
//Copyright 2015 Microsoft Corporation
//
//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:
//
//The above copyright notice and this permission notice shall be included in
//all copies or substantial portions of the Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//THE SOFTWARE.
//
﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EnhancedMonitoring.Configuration
{
    [XmlRoot("Monitor")]
    public class MonitorConfiguration
    {
        [XmlElement("RefreshRate")]
        public Int64 RefreshRate { get; set; }

        [XmlElement("Version")]
        public String Version { get; set; }

        [XmlElement("MaxValueLength")]
        public Int32 MaxValueLength { get; set; }

        [XmlElement("Kvp")]
        public KvpConfiguration Kvp { get; set; }

        [XmlElement("LogLevel")]
        public String LogLevel { get; set; }

        [XmlElement("LogFilePath")]
        public String LogFilePath { get; set; }

        [XmlElement("MaxLogRetain")]
        public Int32 MaxLogRetention { get; set; }

        [XmlElement("LogFileSize")]
        public Int64 LogFileSize { get; set; }

        public Double EventLogInterval { get; set; }

        [XmlElement("DataItemKeyPrefix")]
        public string DataItemKeyPrefix { get; set; }    

        [XmlElement("SupportedVMDetector")]
        public SupportedVMDetectorConfiguration SupportedVMDetector { get; set; }

        [XmlArray("MgmtObjects")]
        [XmlArrayItem("MgmtObject")]
        public MgmtObjectConfigurationList MgmtObjects { get; set; }
        
        public static MonitorConfiguration Load(String path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(MonitorConfiguration));
            using(FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                var conf = serializer.Deserialize(fs);
                return (MonitorConfiguration)conf;
            }
        }
    }

    public class VirtualMachineList : List<String>
    {

    }

    public class MgmtObjectConfigurationList : List<MgmtObjectConfiguration>
    {

    }
}
