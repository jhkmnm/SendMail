using System;
using Dos.ORM;

namespace 邮件群发
{
	/// <summary>
	/// 实体类MailFrom。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("MailFrom")]
	[Serializable]
	public partial class MailFrom : Entity
	{
		#region Model
		private int _ID;
		private string _UserName;
		private string _PassWord;
		private string _Mail;
		private string _Server;
		private int? _Port;

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
		[Field("UserName")]
		public string UserName
		{
			get { return _UserName; }
			set
			{
				this.OnPropertyValueChange("UserName");
				this._UserName = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[Field("PassWord")]
		public string PassWord
		{
			get { return _PassWord; }
			set
			{
				this.OnPropertyValueChange("PassWord");
				this._PassWord = value;
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
		/// <summary>
		/// 
		/// </summary>
		[Field("Server")]
		public string Server
		{
			get { return _Server; }
			set
			{
				this.OnPropertyValueChange("Server");
				this._Server = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		[Field("Port")]
		public int? Port
		{
			get { return _Port; }
			set
			{
				this.OnPropertyValueChange("Port");
				this._Port = value;
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
				_.UserName,
				_.PassWord,
				_.Mail,
				_.Server,
				_.Port,
			};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
				this._ID,
				this._UserName,
				this._PassWord,
				this._Mail,
				this._Server,
				this._Port,
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
			public readonly static Field All = new Field("*", "MailFrom");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ID = new Field("ID", "MailFrom", "");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field UserName = new Field("UserName", "MailFrom", "");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field PassWord = new Field("PassWord", "MailFrom", "");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Mail = new Field("Mail", "MailFrom", "");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Server = new Field("Server", "MailFrom", "");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Port = new Field("Port", "MailFrom", "");
		}
		#endregion
	}
}