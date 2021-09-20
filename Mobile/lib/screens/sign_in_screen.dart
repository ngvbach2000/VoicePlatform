import 'package:flutter/material.dart';
import 'package:voice_platform/constants/constants.dart';

class SignIn extends StatefulWidget {
  @override
  _SignInScreen createState() => _SignInScreen();
}

class _SignInScreen extends State<SignIn> {

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: Scaffold(
        body: Container(
          padding: EdgeInsets.fromLTRB(30, 0, 30, 0),
          constraints: BoxConstraints.expand(),
          color: Colors.white,
          child: Column(
            mainAxisAlignment: MainAxisAlignment.end,
            crossAxisAlignment: CrossAxisAlignment.start,
            children: <Widget>[
              Center(
                child: Column(
                  children: <Widget>[
                    Text("Chào mừng đến với", style: TextStyle(
                        fontWeight: FontWeight.bold,
                        color: appDarkColor,
                        fontFamily: "Montserrat",
                        fontSize: 24),
                    ),
                    Text("Voice Platform!", style: TextStyle(
                        fontWeight: FontWeight.bold,
                        color: appYellowColor,
                        fontFamily: "Montserrat",
                        fontSize: 24),
                    ),
                    Text("Lorem ipsum dolor sit amet, consectetur adipiscing elit.", style: TextStyle(
                        fontWeight: FontWeight.bold,
                        color: appDarkColor,
                        fontFamily: "Montserrat",
                        fontSize: 13),
                    ),
                  ],
                ),
              ),
              Container(
                padding: const EdgeInsets.fromLTRB(0, 30, 0, 10),
                child: TextField(
                  obscureText: true,
                  style: TextStyle(
                    fontSize: 15,
                    height: 1,
                    color: Colors.black,
                  ),
                  decoration: InputDecoration(
                    border: OutlineInputBorder(),
                    labelText: 'Email',
                  ),
                ),
              ),
              Padding(
                padding: const EdgeInsets.fromLTRB(0, 0, 0, 5),
                child: Stack(
                  alignment: AlignmentDirectional.centerEnd,
                  children: <Widget>[
                    TextField(
                      obscureText: true,
                      style: TextStyle(
                        fontSize: 15,
                        height: 1,
                        color: Colors.black,
                      ),
                      decoration: InputDecoration(
                        border: OutlineInputBorder(),
                        labelText: "Mật khẩu",
                        labelStyle: TextStyle(color: Color(0xff888888), fontSize: 15),
                      ),
                    ),
                    IconButton(icon: Icon(Icons.remove_red_eye_outlined), onPressed: (){

                    },),
                  ],
                ),
              ),
              Container(
                padding: const EdgeInsets.fromLTRB(0, 0, 0, 20),
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.end,
                  children: [
                    Text(
                      "Quên mật khẩu?",
                      style: TextStyle(
                          fontFamily: "Poppins",
                          fontSize: 10,
                          color: Colors.black
                      ),
                      textAlign: TextAlign.right,
                    ),
                  ],
                ),
              ),
              Padding(
                padding: const EdgeInsets.fromLTRB(0, 0, 0, 0),
                child: SizedBox(
                  width: double.infinity,
                  height: 40,
                  child: RaisedButton(
                    color: appDarkColor,
                    shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.all(Radius.circular(8))),
                    onPressed: onPressClicked,
                    child: Text(
                      "Đăng nhập",
                      style: TextStyle(color: Colors.white, fontSize: 16),
                    ),
                  ),
                ),
              ),
              Center(
                child: Padding(
                  padding: const EdgeInsets.fromLTRB(0, 150, 0, 0),
                  child: SizedBox(
                    width: double.infinity,
                    height: 42,
                    child: RaisedButton(
                      color: Colors.white,
                      shape: RoundedRectangleBorder(
                          borderRadius: BorderRadius.all(Radius.circular(8))),
                      onPressed: onPressClicked,
                      child: Text(
                        "Sign-in with Google",
                        style: TextStyle(color: Colors.black, fontSize: 16),
                      ),
                    ),
                  ),
                ),
              ),
              Container (
                height: 50,
                width: double.infinity,
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: <Widget>[
                    Text(
                      "Don't have an account?",
                      style: TextStyle(
                          fontSize: 10,
                          color: Color(0xff888888)
                      ),
                    ),
                    Text(
                      "Register",
                      style: TextStyle(
                          fontFamily: "Montserrat",
                          fontSize: 10,
                          fontWeight: FontWeight.bold,
                          color: appDarkColor
                      ),
                    ),
                  ],
                ),
              )
            ],
          ),
        ),
      ),
    );
  }

  void onPressClicked(){

  }
}
