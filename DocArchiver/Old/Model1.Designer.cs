﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]

namespace DocArchiver.Old
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class DocArchiverDBEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new DocArchiverDBEntities object using the connection string found in the 'DocArchiverDBEntities' section of the application configuration file.
        /// </summary>
        public DocArchiverDBEntities() : base("name=DocArchiverDBEntities", "DocArchiverDBEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new DocArchiverDBEntities object.
        /// </summary>
        public DocArchiverDBEntities(string connectionString) : base(connectionString, "DocArchiverDBEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new DocArchiverDBEntities object.
        /// </summary>
        public DocArchiverDBEntities(EntityConnection connection) : base(connection, "DocArchiverDBEntities")
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
    [EdmEntityTypeAttribute(NamespaceName="DocArchiverDBModel", Name="DiskFolder")]
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
        #region Primitive Properties
    
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
                    _DiskFolder_ID = StructuralObject.SetValidValue(value);
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
                _Path = StructuralObject.SetValidValue(value, false);
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
                _IsValid = StructuralObject.SetValidValue(value);
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