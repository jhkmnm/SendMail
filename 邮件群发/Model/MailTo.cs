using System;
using Dos.ORM;

namespace 邮件群发
{
	/// <summary>
	/// 实体类MailTo。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Table("MailTo")]
	[Serializable]
	public partial class MailTo : Entity
	{
		#region Model
		private string _Mail;

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
			};
		}
		/// <summary>
		/// 获取列信息
		/// </summary>
		public override Field[] GetFields()
		{
			return new Field[] {
				_.Mail,
			};
		}
		/// <summary>
		/// 获取值信息
		/// </summary>
		public override object[] GetValues()
		{
			return new object[] {
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
			public readonly static Field All = new Field("*", "MailTo");
			/// <summary>
			/// 
			/// </summary>
			public readonly static Field Mail = new Field("Mail", "MailTo", "");
		}
		#endregion
	}
}