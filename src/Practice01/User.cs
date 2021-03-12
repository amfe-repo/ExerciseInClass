namespace src.Practice01 {

    class User {

        private string user_name = "";
        private string user_pass = "";
        private int user_money = 0;
        private bool admin_validate = false;

        public User(string name, string pass, int money = 0, bool admin = false) {

            this.user_name = name;
            this.user_pass = pass;
            this.user_money = money;
            this.admin_validate = admin;

        }

        public string UserName { 

            get { return this.user_name; } 

            //set { user_name = value; } 

        }

        public string UserPass { 

            get { return this.user_pass; } 
            
            //set { user_pass = value; } 

        }

        public bool AdminValidate { 

            get { return admin_validate; } 
            
            //set { this.user_money = value; } 

        }

        public int UserMoney { 

            get { return user_money; } 
            
            set { this.user_money = value; } 

        }


    };
    
}