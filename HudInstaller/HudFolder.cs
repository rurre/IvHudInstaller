﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hudParse
{
    public class HudFolder
    {
        string m_Name;
        string m_Path;
        bool m_CopyNoParse;
        List<HudFile> m_FileList;
        List<HudFolder> m_SubFolderList;        

        public HudFolder()
        {
            m_Name = "";
            m_Path = "";
            m_FileList = new List<HudFile>();
            m_SubFolderList = new List<HudFolder>();
            m_CopyNoParse = false;
        }

        public string FullName
        {
            get
            {
                return m_Path + m_Name;
            }

            set
            {
                if(value.IndexOf("\\") != -1)
                {
                    m_Name = value.Remove(0,value.LastIndexOf("\\")+1);
                    m_Path = value.Remove(value.Length - m_Name.Length);
                }
                else
                {
                    RefLib.StripAndTrim(ref value);
                    m_Name = value;
                }
            }
        }
        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
            }
        }
        public string Path
        {
            get { return m_Path; }
            set { m_Path = value; }
        }
        public bool IsEmpty
        {
            get
            {
                if((m_FileList.Count > 0) || (m_SubFolderList.Count > 0))
                    return false;
                else return true;
            }
        }
        public bool CopyNoParse
        {
            get
            {
                return m_CopyNoParse;
            }

            set
            {
                m_CopyNoParse = value;
            }
        }          
             
        public void Add(HudFile file)
        {
            m_FileList.Add(file);
        }
        public void Add(HudFolder folder)
        {
            if(folder.FullName == null)
            {
                if(folder.FullName.ToLower() == "new folder")
                {
                    for(int i = 1; folder.FullName == "new folder" + i; i++)
                        folder.FullName = "New Folder " + i;
                }
                else folder.FullName = "New Folder";
            }
            m_SubFolderList.Add(folder);
        }
    }
}
