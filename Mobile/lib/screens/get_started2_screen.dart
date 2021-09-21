import 'package:flutter/material.dart';

class GetStarted2 extends StatelessWidget {
  const GetStarted2({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Center(
      child: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: <Widget>[
          Image.asset(
            'assets/images/get_started2.png',
            fit: BoxFit.cover,
            scale: 5.5,
          ),
          const Text(
            'Title here',
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
              SizedBox(
                height: 43,
                width: 335,
                child: RaisedButton(
                  child: const Text(
                    'Tiếp theo',
                    style: TextStyle(
                      color: Colors.white,
                      fontSize: 20,
                    ),
                  ),
                  onPressed: () {
                    Navigator.pushNamed(context, '/signup');
                  },
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
