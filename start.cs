class Account
    {
        public enum WithdrawalStatus
        {
            Ok,
            CantWithdrawNegativeAmount,
            SaldoTooLow
        }

        private int saldo;

        public Account(int startSaldo)
        {
            saldo = startSaldo;
        }

        public int GetSaldo()
        {
            return saldo;
        }

        public WithdrawalStatus Withdraw(int amount)
        {
            if (amount < 0)
                return WithdrawalStatus.CantWithdrawNegativeAmount;
            if (saldo >= amount)
            {
                saldo -= amount;
                return WithdrawalStatus.Ok;
            }

            return WithdrawalStatus.SaldoTooLow;
        }

    }

    class Bankomat
    {
        public void Run()
        {
            var account = new Account(100);
            if (account.Withdraw(20) == Account.WithdrawalStatus.Ok)
            {
                var nyttSaldo = account.GetSaldo();
                Console.WriteLine($"Nytt saldo: {nyttSaldo}");
            }
            
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            var pgm = new Bankomat();
            pgm.Run();
        }
    }
