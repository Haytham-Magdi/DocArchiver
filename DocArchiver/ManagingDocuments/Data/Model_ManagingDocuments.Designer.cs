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
namespace DocArchiver.ManagingDocuments.Data
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class Ents_ManagingDocuments : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new Ents_ManagingDocuments object using the connection string found in the 'Ents_ManagingDocuments' section of the application configuration file.
        /// </summary>
        public Ents_ManagingDocuments() : base("name=Ents_ManagingDocuments", "Ents_ManagingDocuments")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new Ents_ManagingDocuments object.
        /// </summary>
        public Ents_ManagingDocuments(string connectionString) : base(connectionString, "Ents_ManagingDocuments")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new Ents_ManagingDocuments object.
        /// </summary>
        public Ents_ManagingDocuments(EntityConnection connection) : base(connection, "Ents_ManagingDocuments")
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
        public ObjectSet<Vw_SimpleDocumentsView> Vw_SimpleDocumentsView
        {
            get
            {
                if ((_Vw_SimpleDocumentsView == null))
                {
                    _Vw_SimpleDocumentsView = base.CreateObjectSet<Vw_SimpleDocumentsView>("Vw_SimpleDocumentsView");
                }
                return _Vw_SimpleDocumentsView;
            }
        }
        private ObjectSet<Vw_SimpleDocumentsView> _Vw_SimpleDocumentsView;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Vw_SimpleDocumentsView EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToVw_SimpleDocumentsView(Vw_SimpleDocumentsView vw_SimpleDocumentsView)
        {
            base.AddObject("Vw_SimpleDocumentsView", vw_SimpleDocumentsView);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="Model_ManagingDocuments", Name="Vw_SimpleDocumentsView")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Vw_SimpleDocumentsView : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Vw_SimpleDocumentsView object.
        /// </summary>
        /// <param name="coreFile_ID">Initial value of the CoreFile_ID property.</param>
        /// <param name="size">Initial value of the Size property.</param>
        /// <param name="nofPages">Initial value of the NofPages property.</param>
        /// <param name="importanceDegree_Num">Initial value of the ImportanceDegree_Num property.</param>
        /// <param name="isMissing">Initial value of the IsMissing property.</param>
        /// <param name="isCorrupted">Initial value of the IsCorrupted property.</param>
        /// <param name="isInspected">Initial value of the IsInspected property.</param>
        public static Vw_SimpleDocumentsView CreateVw_SimpleDocumentsView(global::System.Int32 coreFile_ID, global::System.Int64 size, global::System.Int32 nofPages, global::System.Int32 importanceDegree_Num, global::System.Boolean isMissing, global::System.Boolean isCorrupted, global::System.Boolean isInspected)
        {
            Vw_SimpleDocumentsView vw_SimpleDocumentsView = new Vw_SimpleDocumentsView();
            vw_SimpleDocumentsView.CoreFile_ID = coreFile_ID;
            vw_SimpleDocumentsView.Size = size;
            vw_SimpleDocumentsView.NofPages = nofPages;
            vw_SimpleDocumentsView.ImportanceDegree_Num = importanceDegree_Num;
            vw_SimpleDocumentsView.IsMissing = isMissing;
            vw_SimpleDocumentsView.IsCorrupted = isCorrupted;
            vw_SimpleDocumentsView.IsInspected = isInspected;
            return vw_SimpleDocumentsView;
        }

        #endregion

        #region Simple Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 CoreFile_ID
        {
            get
            {
                return _CoreFile_ID;
            }
            set
            {
                if (_CoreFile_ID != value)
                {
                    OnCoreFile_IDChanging(value);
                    ReportPropertyChanging("CoreFile_ID");
                    _CoreFile_ID = StructuralObject.SetValidValue(value, "CoreFile_ID");
                    ReportPropertyChanged("CoreFile_ID");
                    OnCoreFile_IDChanged();
                }
            }
        }
        private global::System.Int32 _CoreFile_ID;
        partial void OnCoreFile_IDChanging(global::System.Int32 value);
        partial void OnCoreFile_IDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int64 Size
        {
            get
            {
                return _Size;
            }
            set
            {
                OnSizeChanging(value);
                ReportPropertyChanging("Size");
                _Size = StructuralObject.SetValidValue(value, "Size");
                ReportPropertyChanged("Size");
                OnSizeChanged();
            }
        }
        private global::System.Int64 _Size;
        partial void OnSizeChanging(global::System.Int64 value);
        partial void OnSizeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 NofPages
        {
            get
            {
                return _NofPages;
            }
            set
            {
                OnNofPagesChanging(value);
                ReportPropertyChanging("NofPages");
                _NofPages = StructuralObject.SetValidValue(value, "NofPages");
                ReportPropertyChanged("NofPages");
                OnNofPagesChanged();
            }
        }
        private global::System.Int32 _NofPages;
        partial void OnNofPagesChanging(global::System.Int32 value);
        partial void OnNofPagesChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ImportanceDegree_Num
        {
            get
            {
                return _ImportanceDegree_Num;
            }
            set
            {
                OnImportanceDegree_NumChanging(value);
                ReportPropertyChanging("ImportanceDegree_Num");
                _ImportanceDegree_Num = StructuralObject.SetValidValue(value, "ImportanceDegree_Num");
                ReportPropertyChanged("ImportanceDegree_Num");
                OnImportanceDegree_NumChanged();
            }
        }
        private global::System.Int32 _ImportanceDegree_Num;
        partial void OnImportanceDegree_NumChanging(global::System.Int32 value);
        partial void OnImportanceDegree_NumChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean IsMissing
        {
            get
            {
                return _IsMissing;
            }
            set
            {
                OnIsMissingChanging(value);
                ReportPropertyChanging("IsMissing");
                _IsMissing = StructuralObject.SetValidValue(value, "IsMissing");
                ReportPropertyChanged("IsMissing");
                OnIsMissingChanged();
            }
        }
        private global::System.Boolean _IsMissing;
        partial void OnIsMissingChanging(global::System.Boolean value);
        partial void OnIsMissingChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean IsCorrupted
        {
            get
            {
                return _IsCorrupted;
            }
            set
            {
                OnIsCorruptedChanging(value);
                ReportPropertyChanging("IsCorrupted");
                _IsCorrupted = StructuralObject.SetValidValue(value, "IsCorrupted");
                ReportPropertyChanged("IsCorrupted");
                OnIsCorruptedChanged();
            }
        }
        private global::System.Boolean _IsCorrupted;
        partial void OnIsCorruptedChanging(global::System.Boolean value);
        partial void OnIsCorruptedChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean IsInspected
        {
            get
            {
                return _IsInspected;
            }
            set
            {
                OnIsInspectedChanging(value);
                ReportPropertyChanging("IsInspected");
                _IsInspected = StructuralObject.SetValidValue(value, "IsInspected");
                ReportPropertyChanged("IsInspected");
                OnIsInspectedChanged();
            }
        }
        private global::System.Boolean _IsInspected;
        partial void OnIsInspectedChanging(global::System.Boolean value);
        partial void OnIsInspectedChanged();

        #endregion

    }

    #endregion

}
