import 'dart:math';

import 'package:flutter/material.dart';

class SignUpScreen extends StatefulWidget {
  @override
  _SignUpScreenState createState() => _SignUpScreenState();
}

const inputFieldStyle = TextStyle(fontSize: 15, height: 0.5);
const whitegray = Color(0xFFF5F5F5);
var isAgree = false;

class _SignUpScreenState extends State<SignUpScreen> {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: Scaffold(
        // appBar: AppBar(
        //   backgroundColor: Colors.yellow,
        //   title: Text('Sign up'),
        // ),
        backgroundColor: Colors.white10,
        body: GestureDetector(
          onTap: () => FocusManager.instance.primaryFocus?.unfocus(),
          child: Container(
            constraints: BoxConstraints.expand(),
            decoration: BoxDecoration(
              image: DecorationImage(
                  image: AssetImage('assets/images/signin-bg.png'),
                  fit: BoxFit.cover),
            ),
            child: Container(
              margin: EdgeInsets.fromLTRB(0, 130, 0, 0),
              child: Column(
                children: <Widget>[
                  Container(
                    child: Text(
                      'Create an account',
                      style: TextStyle(
                        fontSize: 30,
                        fontFamily: 'Montserrat',
                      ),
                    ),
                  ),
                  Container(
                    margin: EdgeInsets.fromLTRB(0, 40, 0, 0),
                    child: Column(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: <Widget>[
                        Container(
                          color: whitegray,
                          child: TextField(
                            decoration: InputDecoration(
                              border: const OutlineInputBorder(),
                              labelText: 'Name',
                            ),
                            style: inputFieldStyle,
                          ),
                          margin: const EdgeInsets.fromLTRB(50, 0, 50, 0),
                        ),
                        Container(
                          color: whitegray,
                          child: TextField(
                            decoration: InputDecoration(
                              border: const OutlineInputBorder(),
                              labelText: 'Email',
                            ),
                            style: inputFieldStyle,
                          ),
                          margin: const EdgeInsets.fromLTRB(50, 15, 50, 0),
                        ),
                        Container(
                          color: whitegray,
                          child: TextField(
                            obscureText: true,
                            decoration: InputDecoration(
                              border: const OutlineInputBorder(),
                              labelText: 'Password',
                            ),
                            style: inputFieldStyle,
                          ),
                          margin: const EdgeInsets.fromLTRB(50, 15, 50, 0),
                        ),
                        Container(
                          margin: EdgeInsets.fromLTRB(40, 0, 0, 0),
                          child: Row(
                            mainAxisAlignment: MainAxisAlignment.start,
                            children: <Widget>[
                              Checkbox(
                                value: isAgree,
                                onChanged: (bool? value) {
                                  setState(() {
                                    isAgree = value!;
                                  });
                                },
                              ),
                              Container(
                                child: Row(
                                  children: <Widget>[
                                    Text(
                                      'I agree to ',
                                      style: TextStyle(
                                        fontFamily: 'Poppins',
                                      ),
                                    ),
                                    Text(
                                      'terms',
                                      style: TextStyle(
                                        fontWeight: FontWeight.bold,
                                        decoration: TextDecoration.underline,
                                        fontFamily: 'Poppins',
                                      ),
                                    ),
                                    Text(
                                      ' and ',
                                      style: TextStyle(
                                        fontFamily: 'Poppins',
                                      ),
                                    ),
                                    Text(
                                      'conditions',
                                      style: TextStyle(
                                        fontWeight: FontWeight.bold,
                                        decoration: TextDecoration.underline,
                                        fontFamily: 'Poppins',
                                      ),
                                    ),
                                  ],
                                ),
                              ),
                            ],
                          ),
                        ),
                        Container(
                          // color: Color(0xFF383838),
                          child: ElevatedButton(
                            onPressed: () {},
                            child: Text('Sign Up'),
                            style: ButtonStyle(
                              backgroundColor: MaterialStateColor.resolveWith(
                                  (states) => Color(0xFF383838)),
                              fixedSize: MaterialStateProperty.resolveWith(
                                (states) => Size.fromWidth(310),
                              ),
                            ),
                          ),
                        ),
                      ],
                    ),
                  ),
                ],
              ),
            ),
          ),
        ),
      ),
    );
  }
}
