using System;

namespace BLL
{
    public class AccountDetails
    {

        public double m_balance { get; set; }

        public void Withdraw(double amount)
        {
            m_balance = 100;

            if (m_balance >= amount)
            {
                m_balance -= amount;
            }
            else
            {
                throw new ArgumentException(amount.ToString(), "Withdrawal exceeds balance!");
            }
        }
    }
}
