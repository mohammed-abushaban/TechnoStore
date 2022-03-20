namespace TechnoStore.Core.Constants
{
    public class Messages
    {
        //For 
        public const string ErrorMessage = "هذا الحقل إجباري" + " * ";

        public const string Max9 = "لا يمكن إدخال أكثر من 9 حرف" + " * ";
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

        public const string NoCategory = "ت: هناك تصنيفات غير مدخلة ، لطفا للتحقق ";
        public const string NoDeleteCategory = "خ: لا يمكن حذف هذا التصنيف لأنه مرتبط في عناصر أخرى  ، لطفا لحذف العناصر ثم حذف التصنيف ";
        public const string NoDeleteShipper = "خ: لا يمكن حذف شركة الشحن ، لوجود طلبات خاصة بالشركة ، يجب حذف الطلبات أولا ";
        public const string NoDeleteSupplier = "خ: لا يمكن حذف شركة التوريد ، لوجود بضائع موردة من خلالها ";

        public const string CanNot = "خ: لا يمكن حذف هذا الحساب ، لأنه آخر حساب ، وفي حال تم حذفه لن تتمكن من الدخول للنظام مرة أخرى";
        public const string CanNot2 = "خ: لا يمكن حذف آخر حساب مسؤول في النظام";
        public const string CanNot3 = "خ: لا يمكن حذف الحساب النشط حاليا";
        public const string CanNotShip = "خ: لا يمكن حذف شركة الشحن الوحيدة المسجلة";

        public const string between = "اسم المستخدم يجب أن يكون ما بين 6 -16 حرف" + " " + "*";
        public const string password = "يجب أن تحتوي كلمة السر على" + " A-Z,a-z" + "والرموز " + "_-." + "ما بين 5-20 حرف";
    }

}