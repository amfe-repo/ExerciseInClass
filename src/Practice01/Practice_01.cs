using System;
using static System.Console;
using System.Collections.Generic;

namespace src.Practice01 {

/* Crear un programa que simule un banco que tiene 3 clientes que pueden
hacer depósitos y retiros. También el banco requiere que al final del
día calcule la cantidad de dinero que hay depositado. */

    class Practice_01 {
        
        Bank bk1 = new Bank();
        static int counter_global = 0;

        public void BankExercise() {
            
            string name = "", pass = "";
            User user_session;

            while(true){

                Clear();

                WriteLine("Bienvenido a su banco de confianza");

                WriteLine("Nota: Si desea salir deje los campos vacios!!");

                Write("Digite su nombre: ");
                name = ReadLine();

                Write("Digite su contraseña: ");
                pass = ReadLine();

                user_session = UserLogin(name, pass);

                Clear();

                if (name.Length == 0 && pass.Length == 0) break;
                
                if (user_session != null) {
                    
                    if (user_session.AdminValidate) {

                        AdminInterface(user_session);

                    }
                    else {

                        UserInterface(user_session);

                    }

                }
                else {

                    WriteLine("\nEl usuario no existe");

                }
            }
   
        }

        private void UserInterface(User session) {

            int selection = 0, money = 0;
            bool loop_control = true;

            while(loop_control){

                Clear();
                WriteLine($"Bienvenido {session.UserName} en su cuenta tiene {session.UserMoney} dolares");

                WriteLine("\n1.Depositar");
                WriteLine("2.Retirar");
                WriteLine("3.Salir");

                Write("\nEscribe una opcion: ");
                selection = int.Parse(ReadLine());

                switch(selection) {

                    case 1:

                        Write("Dame la suma a depositar: ");
                        money = int.Parse(ReadLine());
                        session.UserMoney += money;
                        bk1.BankMonto += money;
                        break;

                    case 2:

                        Write("Dame la suma a retirar: ");
                        money = int.Parse(ReadLine());
                        session.UserMoney -= money;
                        bk1.BankMonto -= money;
                        break;

                    case 3:

                        loop_control = false;
                        break;

                    default:

                        WriteLine("La opcion seleccionada no existe");
                        break;

                }

                WriteLine("Presione cualquier tecla para continuar");
                ReadKey();
            }
            
        }

        private void AdminInterface(User session) {

            WriteLine("Esta interfaz solo permite ve la suma de dinero que tiene el banco en total");
            WriteLine($"\nEl banco tiene en total {bk1.BankMonto}");

            WriteLine("Presione cualquier tecla para continuar");
            ReadKey();
        }



        private User UserLogin(string name, string pass) {

            int index = 0;

            User[] user_db = new User[] {

                new User("pepe", "1234", 1000),
                new User("marta", "5432", 2000),
                new User("pablo", "0987", 3000),
                new User("admin", "admin_0989", admin: true)

            };
            
            if (counter_global == 0) {

                foreach (var person in user_db) {
    
                    bk1.BankMonto += person.UserMoney;
        
                }
                counter_global = counter_global + 1;
            }
            

            index = VerifyUser(user_db, name, pass);

            if(index >= 0) {

                return user_db[index];
                
            }
            
            return null;

        }

        private int VerifyUser(User[] db, string name, string pass) {
            
            int counter = 0;

            foreach (var item in db) {

                if(item.UserName == name && item.UserPass == pass) {

                    return counter; 

                }
        
                counter++;
            }

            return -1;
        }



    };
}


