using System;
using Dos.ORM;

namespace 邮件群发
{
	/// <summary>
	/// 实体类Server。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("Server")]
	[Serializable]
	public partial class Server : Entity
	{
		#region Model
		private int _ID;
		private string _Name;
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
		[Field("Name")]
		public string Name
		{
			get { return _Name; }
			set
			{
				this.OnPropertyValueChange("Name");
				this._Name = value;
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
				_.Name,
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
				this._Name,
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
			public readonly static Field All = new Field("*", "Server");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field ID = new Field("ID", "Server", "");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Name = new Field("Name", "Server", "");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Port = new Field("Port", "Server", "");
		}
		#endregion
	}
}