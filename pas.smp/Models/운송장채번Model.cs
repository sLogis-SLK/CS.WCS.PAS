namespace PAS.SMP
{
    public class 운송장채번Model
    {
        private bool m채번여부 = false;
        private string m메시지 = string.Empty;
        private string m운송장번호 = string.Empty;
        private string m출력값1= string.Empty;
        private string m출력값2= string.Empty;
        private string m출력값3= string.Empty;
        private string m출력값4= string.Empty;
        private string m출력값5= string.Empty;
        private string m출력값6 = string.Empty;
        private string m배송사코드 = string.Empty;

        public bool 채번여부 { get => m채번여부; set => m채번여부 = value; }
        public string 메시지 { get => m메시지; set => m메시지 = value; }
        public string 운송장번호 { get => m운송장번호; set => m운송장번호 = value; }
        public string 출력값1 { get => m출력값1; set => m출력값1 = value; }
        public string 출력값2 { get => m출력값2; set => m출력값2 = value; }
        public string 출력값3 { get => m출력값3; set => m출력값3 = value; }
        public string 출력값4 { get => m출력값4; set => m출력값4 = value; }
        public string 출력값5 { get => m출력값5; set => m출력값5 = value; }
        public string 출력값6 { get => m출력값6; set => m출력값6 = value; }
        public string 배송사코드 { get => m배송사코드; set => m배송사코드 = value; }
    }
}