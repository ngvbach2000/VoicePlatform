import 'dart:math';

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class SignUpScreen extends StatefulWidget {
  @override
  _SignUpScreenState createState() => _SignUpScreenState();
}

const inputFieldStyle = TextStyle(fontSize: 15, height: 0.5);
const whitegray = Color(0xFFF5F5F5);
const dark = Color(0xFF383838);
var isAgree = false;
bool _isObscure = true;

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
              margin: EdgeInsets.fromLTRB(0, 135, 0, 0),
              child: Column(
                children: <Widget>[
                  Container(
                    child: Text(
                      'Create an account',
                      style: TextStyle(
                        fontSize: 27,
                        fontFamily: 'Montserrat',
                        fontWeight: FontWeight.bold,
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
                            obscureText: _isObscure,
                            decoration: InputDecoration(
                              border: const OutlineInputBorder(),
                              labelText: 'Password',
                              suffixIcon: IconButton(
                                icon: Icon(
                                  _isObscure
                                      ? Icons.visibility
                                      : Icons.visibility_off,
                                ),
                                onPressed: () {
                                  setState(() {
                                    _isObscure = !_isObscure;
                                  });
                                },
                              ),
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
                                checkColor: Colors.yellow,
                                activeColor: dark,
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
                                        fontSize: 12,
                                        fontFamily: 'Poppins',
                                      ),
                                    ),
                                    Text(
                                      'terms',
                                      style: TextStyle(
                                        fontWeight: FontWeight.bold,
                                        decoration: TextDecoration.underline,
                                        fontSize: 12,
                                        fontFamily: 'Poppins',
                                      ),
                                    ),
                                    Text(
                                      ' and ',
                                      style: TextStyle(
                                        fontSize: 12,
                                        fontFamily: 'Poppins',
                                      ),
                                    ),
                                    Text(
                                      'conditions',
                                      style: TextStyle(
                                        fontWeight: FontWeight.bold,
                                        decoration: TextDecoration.underline,
                                        fontSize: 12,
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
                                  (states) => dark),
                              fixedSize: MaterialStateProperty.resolveWith(
                                (states) => Size.fromWidth(310),
                              ),
                            ),
                          ),
                        ),
                        Container(),
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
