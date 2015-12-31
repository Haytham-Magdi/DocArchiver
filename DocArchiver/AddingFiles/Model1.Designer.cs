﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
namespace DocArchiver.AddingFiles
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class DocArchiverDBEntities1 : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new DocArchiverDBEntities1 object using the connection string found in the 'DocArchiverDBEntities1' section of the application configuration file.
        /// </summary>
        public DocArchiverDBEntities1() : base("name=DocArchiverDBEntities1", "DocArchiverDBEntities1")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new DocArchiverDBEntities1 object.
        /// </summary>
        public DocArchiverDBEntities1(string connectionString) : base(connectionString, "DocArchiverDBEntities1")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new DocArchiverDBEntities1 object.
        /// </summary>
        public DocArchiverDBEntities1(EntityConnection connection) : base(connection, "DocArchiverDBEntities1")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<DiskFile> DiskFiles
        {
            get
            {
                if ((_DiskFiles == null))
                {
                    _DiskFiles = base.CreateObjectSet<DiskFile>("DiskFiles");
                }
                return _DiskFiles;
            }
        }
        private ObjectSet<DiskFile> _DiskFiles;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<DiskFolder> DiskFolders
        {
            get
            {
                if ((_DiskFolders == null))
                {
                    _DiskFolders = base.CreateObjectSet<DiskFolder>("DiskFolders");
                }
                return _DiskFolders;
            }
        }
        private ObjectSet<DiskFolder> _DiskFolders;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the DiskFiles EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToDiskFiles(DiskFile diskFile)
        {
            base.AddObject("DiskFiles", diskFile);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the DiskFolders EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToDiskFolders(DiskFolder diskFolder)
        {
            base.AddObject("DiskFolders", diskFolder);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="DocArchiverDBModel1", Name="DiskFile")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class DiskFile : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new DiskFile object.
        /// </summary>
        /// <param name="file_ID">Initial value of the File_ID property.</param>
        /// <param name="name">Initial value of the Name property.</param>
        /// <param name="org_FolderPath">Initial value of the Org_FolderPath property.</param>
        public static DiskFile CreateDiskFile(global::System.Int32 file_ID, global::System.String name, global::System.String org_FolderPath)
        {
            DiskFile diskFile = new DiskFile();
            diskFile.File_ID = file_ID;
            diskFile.Name = name;
            diskFile.Org_FolderPath = org_FolderPath;
            return diskFile;
        }

        #endregion

        #region Simple Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 File_ID
        {
            get
            {
                return _File_ID;
            }
            set
            {
                if (_File_ID != value)
                {
                    OnFile_IDChanging(value);
                    ReportPropertyChanging("File_ID");
                    _File_ID = StructuralObject.SetValidValue(value, "File_ID");
                    ReportPropertyChanged("File_ID");
                    OnFile_IDChanged();
                }
            }
        }
        private global::System.Int32 _File_ID;
        partial void OnFile_IDChanging(global::System.Int32 value);
        partial void OnFile_IDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false, "Name");
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Org_FolderPath
        {
            get
            {
                return _Org_FolderPath;
            }
            set
            {
                OnOrg_FolderPathChanging(value);
                ReportPropertyChanging("Org_FolderPath");
                _Org_FolderPath = StructuralObject.SetValidValue(value, false, "Org_FolderPath");
                ReportPropertyChanged("Org_FolderPath");
                OnOrg_FolderPathChanged();
            }
        }
        private global::System.String _Org_FolderPath;
        partial void OnOrg_FolderPathChanging(global::System.String value);
        partial void OnOrg_FolderPathChanged();

        #endregion

    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="DocArchiverDBModel1", Name="DiskFolder")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class DiskFolder : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new DiskFolder object.
        /// </summary>
        /// <param name="diskFolder_ID">Initial value of the DiskFolder_ID property.</param>
        /// <param name="path">Initial value of the Path property.</param>
        /// <param name="isValid">Initial value of the IsValid property.</param>
        public static DiskFolder CreateDiskFolder(global::System.Int32 diskFolder_ID, global::System.String path, global::System.Boolean isValid)
        {
            DiskFolder diskFolder = new DiskFolder();
            diskFolder.DiskFolder_ID = diskFolder_ID;
            diskFolder.Path = path;
            diskFolder.IsValid = isValid;
            return diskFolder;
        }

        #endregion

        #region Simple Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 DiskFolder_ID
        {
            get
            {
                return _DiskFolder_ID;
            }
            set
            {
                if (_DiskFolder_ID != value)
                {
                    OnDiskFolder_IDChanging(value);
                    ReportPropertyChanging("DiskFolder_ID");
                    _DiskFolder_ID = StructuralObject.SetValidValue(value, "DiskFolder_ID");
                    ReportPropertyChanged("DiskFolder_ID");
                    OnDiskFolder_IDChanged();
                }
            }
        }
        private global::System.Int32 _DiskFolder_ID;
        partial void OnDiskFolder_IDChanging(global::System.Int32 value);
        partial void OnDiskFolder_IDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Path
        {
            get
            {
                return _Path;
            }
            set
            {
                OnPathChanging(value);
                ReportPropertyChanging("Path");
                _Path = StructuralObject.SetValidValue(value, false, "Path");
                ReportPropertyChanged("Path");
                OnPathChanged();
            }
        }
        private global::System.String _Path;
        partial void OnPathChanging(global::System.String value);
        partial void OnPathChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean IsValid
        {
            get
            {
                return _IsValid;
            }
            set
            {
                OnIsValidChanging(value);
                ReportPropertyChanging("IsValid");
                _IsValid = StructuralObject.SetValidValue(value, "IsValid");
                ReportPropertyChanged("IsValid");
                OnIsValidChanged();
            }
        }
        private global::System.Boolean _IsValid;
        partial void OnIsValidChanging(global::System.Boolean value);
        partial void OnIsValidChanged();

        #endregion

    }

    #endregion

}
