namespace TechnoStore.Core.Constants
{
    public class Messages
    {
        //مؤقا لحين حل المشكلة بطريقة أفضل 
        public const string ErrorMessage = "هذا الحقل إجباري" + " * ";
        public const string Max10 = "لا يمكن إدخال أكثر من 10 حرف" + " * ";
        public const string Max14 = "لا يمكن إدخال أكثر من 14 حرف" + " * ";
        public const string Max25 = "لا يمكن إدخال أكثر من 25 حرف" + " * ";
        public const string Max50 = "لا يمكن إدخال أكثر من 50 حرف" + " * ";
        public const string Max100 = "لا يمكن إدخال أكثر من 100 حرف" + " * ";
        public const string Max150 = "لا يمكن إدخال أكثر من 150 حرف" + " * ";
        public const string Max2000 = "لا يمكن إدخال أكثر من 2000 حرف" + " * ";
        public const string Max4000 = "لا يمكن إدخال أكثر من 4000 حرف" + " * ";



        public const string AddAction = "ا: تم إضافة العنصر بنجاح ";
        public const string EditAction = "ا: تم تعديل العنصر المحدد بنجاح ";
        public const string DeleteActon = "ا: تم حذف العنصر بنجاح ";
        public const string Dublecate = "خ: البريد الإلكتروني أو رقم الجوال موجود مسبقا ";

        public const string NameExest = "ت: الإسم موجود مسبقا ";
        public const string NoCategory = "ت: الرجاء إضافة تصنيف قبل إضافة المصروف ";
        public const string NoDeleteCategory = "خ: هذا التصنيف مرتبط بمصروفات أخرى ، في حال حذف التصنيف سيتم حذف كافة المصروفات التابعة له ";
        

        public const string CanNot = "خ: لا يمكن حذف هذا الحساب ، لأنه آخر حساب ، وفي حال تم حذفه لن تتمكن من الدخول للنظام مرة أخرى";
        public const string CanNot2 = "خ: لا يمكن حذف آخر حساب مسؤول في النظام";
        public const string CanNot3 = "خ: لا يمكن حذف الحساب النشط حاليا";
    }
}
