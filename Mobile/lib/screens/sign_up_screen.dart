import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';

class SignUpScreen extends StatefulWidget {
  const SignUpScreen({Key? key}) : super(key: key);

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
            constraints: const BoxConstraints.expand(),
            decoration: const BoxDecoration(
              image: DecorationImage(image: AssetImage('assets/images/signin-bg.png'), fit: BoxFit.cover),
            ),
            child: Container(
              margin: const EdgeInsets.only(top: 135),
              child: Column(
                children: <Widget>[
                  const Text(
                    'Create an account',
                    style: TextStyle(
                      fontSize: 27,
                      fontFamily: 'Montserrat',
                      fontWeight: FontWeight.bold,
                    ),
                  ),
                  Container(
                    margin: const EdgeInsets.only(top: 40),
                    child: Column(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: <Widget>[
                        Container(
                          color: whitegray,
                          child: const TextField(
                            decoration: InputDecoration(
                              border: OutlineInputBorder(),
                              labelText: 'Name',
                            ),
                            style: inputFieldStyle,
                          ),
                          margin: const EdgeInsets.fromLTRB(50, 0, 50, 0),
                        ),
                        Container(
                          color: whitegray,
                          child: const TextField(
                            decoration: InputDecoration(
                              border: OutlineInputBorder(),
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
                                  _isObscure ? Icons.visibility : Icons.visibility_off,
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
                          margin: const EdgeInsets.only(left: 40),
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
                              Row(
                                children: const <Widget>[
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
                            ],
                          ),
                        ),
                        ElevatedButton(
                          onPressed: () {},
                          child: const Text(
                            'Sign Up',
                            style: TextStyle(
                              fontFamily: 'Montserrat',
                              fontWeight: FontWeight.bold,
                            ),
                          ),
                          style: ButtonStyle(
                            backgroundColor: MaterialStateColor.resolveWith((states) => dark),
                            fixedSize: MaterialStateProperty.resolveWith(
                              (states) => const Size.fromWidth(310),
                            ),
                          ),
                        ),
                        ElevatedButton(
                          onPressed: () {},
                          child: Row(
                            mainAxisAlignment: MainAxisAlignment.center,
                            children: <Widget>[
                              SvgPicture.asset('assets/images/google.svg'),
                              const Text(
                                'Continue with Google',
                                style: TextStyle(
                                  fontFamily: 'Montserrat',
                                  color: dark,
                                  fontWeight: FontWeight.bold,
                                ),
                              ),
                            ],
                          ),
                          style: ButtonStyle(
                            backgroundColor: MaterialStateColor.resolveWith((states) => Colors.white),
                            fixedSize: MaterialStateProperty.resolveWith(
                              (states) => const Size.fromWidth(310),
                            ),
                          ),
                        ),
                        Container(
                          margin: const EdgeInsets.only(left: 30),
                          child: Row(
                            mainAxisAlignment: MainAxisAlignment.center,
                            children: <Widget>[
                              const Text(
                                'Already have an account? ',
                                style: TextStyle(
                                  fontFamily: 'Poppins',
                                  fontSize: 10,
                                ),
                              ),
                              TextButton(
                                onPressed: () {},
                                child: const Text(
                                  'Sign in',
                                  style: TextStyle(
                                    fontFamily: 'Poppins',
                                    fontSize: 10,
                                    fontWeight: FontWeight.bold,
                                    color: dark,
                                    decoration: TextDecoration.underline,
                                  ),
                                ),
                                style: ButtonStyle(
                                  padding:
                                      MaterialStateProperty.resolveWith((states) => const EdgeInsets.only(right: 30)),
                                ),
                              )
                            ],
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
