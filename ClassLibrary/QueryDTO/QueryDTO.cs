using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.QueryDTO
{
    public interface ISortTerm
    {
        string Sort { set; }
        bool Descending { get; }
        string Name { get; }
    }


    public enum FilterOperator
    {
        Equals,
        NotEquals,
        GreaterThan,
        LessThan,
        GreaterThanOrEqualTo,
        LessThanOrEqualTo,
        Contains,
        StartsWith,
    }
    /*
     
==	Equals
!=	Not equals
>	Greater than
<	Less than
>=	Greater than or equal to
<=	Less than or equal to
@=	Contains
_=	Starts with
!@=	Does not Contains
!_=	Does not Starts with
         
         */

    public class QueryModel
    {
        string Filters { get; set; }

        string Sorts { get; set; }

        int? Skip { get; set; }

        int? Take { get; set; }
    }

    public class SortTerm : ISortTerm, IEquatable<SortTerm>
    {
        public SortTerm() { }

        private string _sort;

        public string Sort
        {
            set
            {
                _sort = value;
            }
        }

        public string Name => (_sort.StartsWith("-")) ? _sort.Substring(1) : _sort;

        public bool Descending => _sort.StartsWith("-");

        public bool Equals(SortTerm other)
        {
            return Name == other.Name
                && Descending == other.Descending;
        }
    }

}
