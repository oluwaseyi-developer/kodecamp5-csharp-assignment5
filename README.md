# 💳 Simple Banking System – C# Console Application

## 👨‍💻 Author
**Samuel Adetogun**

---

## 📘 Task Overview

**C# Beginner Programming Task**  
**Project:** Build a console-based application that simulates a simple **banking system**, allowing users to manage accounts, deposit and withdraw money, and check balances.

---

## ✅ Features Implemented

### 💡 Core Functionalities

- Create a **BankAccount** with:
  - `AccountNumber`
  - `AccountHolder`
  - `BVN`
  - `PIN`
  - `Balance`

- Users can:
  - Deposit and withdraw money (with validation).
  - Check account balance.
  - View account name by account number.
  - Secure access using PIN validation.
  - Create **multiple bank accounts** dynamically.
  - Prevent zero or negative deposits.

### 🛡️ Security & Validation
- Validates:
  - Full name (letters and spaces only)
  - BVN (10-digit, numeric, unique)
  - PIN (4-digit numeric)
  - Account number (unique 10-digit starting with `05`)
- Allows max **3 PIN attempts** for secure transactions.

---

## 🧪 Sample Console Interaction

```text
********** Welcome to Simple Bank! **********
1. Create An Account With Simple Bank
2. Deposit Money
3. Withdraw Money
4. Check Balance
5. Exit

Enter Your Respnse here: 1
Enter Your Full Name Here: Samuel Adetogun
Enter Your Bvn Here: 1234567890
Create Pin For Your New Generated Account 0512345678 Here: 1234

Congratulations! Account Number 0512345678 and Pin 1234 Created Successfully.
