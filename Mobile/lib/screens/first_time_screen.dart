import 'package:flutter/material.dart';

class FirstTime extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Center(
      child: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: <Widget>[
          Container(
            child: Image.asset(
              'assets/images/logo.png',
              fit: BoxFit.cover,
              scale: 2.0,
            ),
          ),
          const Text(
            'Voice Platform',
            style: TextStyle(
              fontSize: 30,
              fontWeight: FontWeight.normal,
              fontFamily: 'Gugi',
            ),
          ),
        ],
      ),
    );
  }
}
