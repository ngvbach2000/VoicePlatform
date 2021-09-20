import 'package:flutter/material.dart';

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
            'Get started',
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
                  child: const Text('Skip',
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
                    'Next',
                    style: TextStyle(
                      color: Colors.white,
                      fontSize: 20,
                    ),
                  ),
                  onPressed: () {},
                  color: Colors.black54,
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
