import 'package:flutter/material.dart';

class FirstTime extends StatelessWidget {
  const FirstTime({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      child: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            Image.asset(
              'assets/images/logo.png',
              fit: BoxFit.cover,
              scale: 2.0,
            ),
            const Text(
              'Voice Platform',
              style: TextStyle(
                fontSize: 30,
                fontWeight: FontWeight.normal,
                fontFamily: 'Gugi',
              ),
            ),
            const SizedBox(
              width: 300,
              height: 50,
              child: Text(
                'Xin vui lòng nhấn vào logo để tiếp tục.',
                style: TextStyle(
                  fontSize: 15,
                  fontWeight: FontWeight.normal,
                  fontFamily: 'Montserrat',
                ),
              ),
            ),
          ],
        ),
      ),
      onTap: () => Navigator.pushNamed(context, '/get1'),
    );
  }
}
