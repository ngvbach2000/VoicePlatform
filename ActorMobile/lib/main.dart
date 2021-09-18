import 'package:flutter/material.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  // This widget is the root of your application.
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
              Padding(
                padding: const EdgeInsets.fromLTRB(0, 0, 0, 60),
                child: Text("Welcome to\nVoice Platform", style: TextStyle(
                  fontWeight: FontWeight.bold,
                  color: Colors.yellow,
                  fontSize: 30),
                ),
              ),
              Padding(
                padding: const EdgeInsets.fromLTRB(0, 0, 0, 40),
                child: TextField(
                  style: TextStyle(fontSize: 15, color: Colors.black),
                  decoration: InputDecoration(labelText: "Email",
                      labelStyle: TextStyle(color: Color(0xff888888), fontSize: 15)),
                ),
              ),
              Padding(
                padding: const EdgeInsets.fromLTRB(0, 0, 0, 40),
                child: Stack(
                  alignment: AlignmentDirectional.centerEnd,
                  children: <Widget>[
                    TextField(
                      style: TextStyle(fontSize: 15, color: Colors.black),
                      obscureText: true,
                      decoration: InputDecoration(labelText: "Password",
                          labelStyle: TextStyle(color: Color(0xff888888), fontSize: 15)),
                    ),
                    IconButton(icon: Icon(Icons.remove_red_eye_outlined), onPressed: (){

                    },),
                  ],
                ),
              ),
              Container(
                child: Text(
                  "Forgot password?",
                  style: TextStyle(fontSize: 15, color: Colors.blue),
                  textAlign: TextAlign.right,
                ),
              ),
              Padding(
                padding: const EdgeInsets.fromLTRB(0, 0, 0, 0),
                child: SizedBox(
                  width: double.infinity,
                  height: 56,
                  child: RaisedButton(
                    color: Colors.blue,
                    shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.all(Radius.circular(8))),
                    onPressed: null,
                    child: Text(
                      "SIGN IN",
                      style: TextStyle(color: Colors.white, fontSize: 16),
                    ),
                  ),
                ),
              ),
              Container (
                height: 130,
                width: double.infinity,
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  children: <Widget>[
                    Text(
                      "Don't have an account? Register",
                      style: TextStyle(fontSize: 8, color: Color(0xff888888)),
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
}
