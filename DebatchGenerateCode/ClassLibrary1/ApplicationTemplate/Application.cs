using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ClassLibrary1.ApplicationTemplate
{
    class ClassApplication
    {
        public string GetApplicationModel(List<MemberFromInfo> listMember)
        {
            StringBuilder sb = new StringBuilder();
            string strMain = listMember[0].TypeName;
            sb.AppendLine(string.Format(string.Format(@"	using System;	", "")));
            sb.AppendLine(string.Format(string.Format(@"		", "")));
            sb.AppendLine(string.Format(string.Format(@"	namespace Fusion.Context.BasicInfo.Application.Models.Product.{0}s	", strMain)));
            sb.AppendLine(string.Format(string.Format(@"	_左括号_	", "")));
            sb.AppendLine(string.Format(string.Format(@"	    public class {0}Model	", strMain)));
            sb.AppendLine(string.Format(string.Format(@"	    _左括号_	", "")));
            sb.AppendLine(string.Format(string.Format(@"	        public {0} {1} _左括号_ get; set; _右括号_	", listMember[1].TypeName, listMember[1].Name)));
            sb.AppendLine(string.Format(string.Format(@"	        public {0} {1} _左括号_ get; set; _右括号_	", listMember[2].TypeName, listMember[2].Name)));
            sb.AppendLine(string.Format(string.Format(@"	        public {0} {1} _左括号_ get; set; _右括号_	", listMember[3].TypeName, listMember[3].Name)));
            sb.AppendLine(string.Format(string.Format(@"	        public {0} {1} _左括号_ get; set; _右括号_	", listMember[4].TypeName, listMember[4].Name)));
            sb.AppendLine(string.Format(string.Format(@"	        public {0} {1} _左括号_ get; set; _右括号_	", listMember[5].TypeName, listMember[5].Name)));
            sb.AppendLine(string.Format(string.Format(@"	        public {0} {1} _左括号_ get; set; _右括号_	", listMember[6].TypeName, listMember[6].Name)));
            sb.AppendLine(string.Format(string.Format(@"	        public {0} {1} _左括号_ get; set; _右括号_	", listMember[7].TypeName, listMember[7].Name)));
            sb.AppendLine(string.Format(string.Format(@"	        public {0} {1} _左括号_ get; set; _右括号_	", listMember[8].TypeName, listMember[8].Name)));
            sb.AppendLine(string.Format(string.Format(@"	    _右括号_	", "")));
            sb.AppendLine(string.Format(string.Format(@"	_右括号_	", "")));
            return sb.ToString();
        }
        public string GetApplicationStore(List<MemberFromInfo> listMember)
        {
            StringBuilder sb = new StringBuilder();
            string strMain = listMember[0].TypeName;
            return sb.ToString();
        }
    }
}
