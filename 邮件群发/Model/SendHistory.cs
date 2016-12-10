using System;
using Dos.ORM;

namespace 邮件群发
{
    /// <summary>
    /// 实体类SendHistory。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Table("SendHistory")]
    [Serializable]
    public partial class SendHistory : Entity
    {
        #region Model
        private int _ID;
        private string _Mail;

        /// <summary>
        /// 
        /// </summary>
        [Field("ID")]
        public int ID
        {
            get { return _ID; }
            set
            {
                this.OnPropertyValueChange("ID");
                this._ID = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Field("Mail")]
        public string Mail
        {
            get { return _Mail; }
            set
            {
                this.OnPropertyValueChange("Mail");
                this._Mail = value;
            }
        }
        #endregion

        #region Method
        /// <summary>
        /// 获取实体中的主键列
        /// </summary>
        public override Field[] GetPrimaryKeyFields()
        {
            return new Field[] {
				_.ID,
			};
        }
        /// <summary>
        /// 获取实体中的标识列
        /// </summary>
        public override Field GetIdentityField()
        {
            return _.ID;
        }
        /// <summary>
        /// 获取列信息
        /// </summary>
        public override Field[] GetFields()
        {
            return new Field[] {
				_.ID,
				_.Mail,
			};
        }
        /// <summary>
        /// 获取值信息
        /// </summary>
        public override object[] GetValues()
        {
            return new object[] {
				this._ID,
				this._Mail,
			};
        }
        /// <summary>
        /// 是否是v1.10.5.6及以上版本实体。
        /// </summary>
        /// <returns></returns>
        public override bool V1_10_5_6_Plus()
        {
            return true;
        }
        #endregion

        #region _Field
        /// <summary>
        /// 字段信息
        /// </summary>
        public class _
        {
            /// <summary>
            /// * 
            /// </summary>
            public readonly static Field All = new Field("*", "SendHistory");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field ID = new Field("ID", "SendHistory", "");
            /// <summary>
            /// 
            /// </summary>
            public readonly static Field Mail = new Field("Mail", "SendHistory", "");
        }
        #endregion
    }
}