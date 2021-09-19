import 'package:flutter/material.dart';

class GetStarted1 extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Center(
      child: Container(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            Container(
              child: Image.asset(
                'assets/images/get_started1.png',
                fit: BoxFit.cover,
                scale: 5.5,
              ),
            ),
            Text(
              'Get started',
              style: TextStyle(
                fontSize: 25,
                fontWeight: FontWeight.bold,
                fontFamily: 'Montserrat',
              ),
            ),
            SizedBox(
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
            Container(
              child: Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: <Widget>[
                  Container(
                    margin: EdgeInsets.fromLTRB(40,0,40,0),
                    child: FlatButton(
                      child: Text('Skip',
                          style: TextStyle(
                            fontSize: 20,
                          )),
                      onPressed: () {},
                    ),
                  ),
                  Container(
                    margin: EdgeInsets.fromLTRB(40,0,40,0),
                    child: RaisedButton(
                      child: Text(
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
            ),
          ],
        ),
      ),
    );
  }
}
