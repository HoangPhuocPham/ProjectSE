using System;
using System.Collections.Generic;

namespace pj.DesignPatterm.Prototype
{
    public abstract class PaymentPrototype
    {
        public abstract PaymentPrototype Clone();
    }

    public class Payment : PaymentPrototype
    {
        private string type;
        public Payment(string type)
        {
            this.type = type;
        }

        public string getType()
        {
            return this.type;
        }

        public int getSale()
        {
            if(this.type == "Offline Payment")
            {
                return 10;
            }
            else if(this.type == "Credit Card")
            {
                return 5;
            }
            else
            {
                return 0;
            }
        }
        public override PaymentPrototype Clone()
        {
            return this.MemberwiseClone() as PaymentPrototype;
        }
    }

    public class PaymentManager
    {
        private Dictionary<string, PaymentPrototype> _payment = new Dictionary<string, PaymentPrototype>();
        public PaymentPrototype this[string key]
        {
            get {return _payment[key]; }
            set {_payment.Add(key, value); }
        } 
    }

    public class PrototypePattern
    {
        public static void Run()
        {
            PaymentManager paymentManager = new PaymentManager();
            paymentManager["creditcard"] = new Payment("Credit Card");
            paymentManager["offlinePayment"] = new Payment("Offline Payment");

            Payment payment1 = paymentManager["creditcard"].Clone() as Payment;
            Payment payment2 = paymentManager["offlinePayment"].Clone() as Payment;
            Console.WriteLine($"{payment1.getType()}: {payment1.getSale()}%");
            Console.WriteLine($"{payment2.getType()}: {payment2.getSale()}%");
        }
    }
}
/*
    _ Cung cấp và sử dụng object này như 1 template khi cần tạo đối tượng mới
    _ Khi tạo đối tượng, dựa trên đối tượng mẫu ko cần dùng toán tử new hay constructor
    _ Mục đích: che giấu thông tin của object, chỉ cung cấp ra ngoài 1 lượng thông tin giới hạn
*/