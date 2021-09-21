import 'package:flutter/material.dart';

import '../constants/constants.dart';

class GetStarted1 extends StatelessWidget {
  const GetStarted1({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Center(
      child: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: <Widget>[
          Image.asset(
            'assets/images/get_started1.png',
            fit: BoxFit.cover,
            scale: 5.5,
          ),
          const Text(
            'Bắt đầu',
            style: TextStyle(
              fontSize: 25,
              fontWeight: FontWeight.bold,
              fontFamily: 'Montserrat',
            ),
          ),
          const SizedBox(
            width: 300,
            height: 100,
            child: Text(
              'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Elementum senectus ultricies accumsan mauris nec imperdiet et interdum diam.',
              style: TextStyle(
                fontSize: 15,
                fontWeight: FontWeight.normal,
                fontFamily: 'Montserrat',
              ),
            ),
          ),
          Row(
            mainAxisAlignment: MainAxisAlignment.center,
            children: <Widget>[
              Container(
                margin: const EdgeInsets.fromLTRB(40, 0, 40, 0),
                child: FlatButton(
                  child: const Text('Bỏ qua',
                      style: TextStyle(
                        fontSize: 20,
                      )),
                  onPressed: () {},
                ),
              ),
              Container(
                margin: const EdgeInsets.fromLTRB(40, 0, 40, 0),
                child: RaisedButton(
                  child: const Text(
                    'Tiếp theo',
                    style: TextStyle(
                      color: Colors.white,
                      fontSize: 20,
                    ),
                  ),
                  onPressed: () {
                    Navigator.pushNamed(context, '/get2');
                  },
                  color: appDarkColor,
                  shape: const RoundedRectangleBorder(
                    borderRadius: BorderRadius.all(Radius.circular(5)),
                  ),
                ),
              ),
            ],
          ),
        ],
      ),
    );
  }
}
