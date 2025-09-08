using Infragistics.Win;

namespace PAS.PMP
{
    internal class ValueListUtil
    {
        internal static class ValueItemList
        {
            public static ValueList ValueList_출하위치()
            {
                ValueList oValueList = new ValueList();
                oValueList.ValueListItems.Add("0", "사용안함");
                oValueList.ValueListItems.Add("1", "A라인");
                oValueList.ValueListItems.Add("2", "B라인");
                oValueList.ValueListItems.Add("3", "균등");
                return oValueList;
            }

            public static ValueList ValueList_분류실적처리()
            {
                ValueList oValueList = new ValueList();
                oValueList.ValueListItems.Add("0", "백업");
                //oValueList.ValueListItems.Add("1", "삭제");
                return oValueList;
            }
        }
    }
}
