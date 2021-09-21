import 'package:flutter/material.dart';

import '../constants/constants.dart';

class SearchActorBar extends StatefulWidget {
  @override
  _SearchActorBarState createState() => _SearchActorBarState();
}

class _SearchActorBarState extends State<SearchActorBar> {
  static const inputFieldStyle = TextStyle(fontSize: 15, height: 0.5);

  @override
  Widget build(BuildContext context) {
    return Container(
      child: Row(

        children: <Widget>[
          Container(
            color: whitegray,
            child: const TextField(
              decoration: InputDecoration(
                border: OutlineInputBorder(),
                labelText: 'Email',
              ),
              style: inputFieldStyle,
            ),
            // margin: const EdgeInsets.fromLTRB(50, 15, 50, 0),
          ),
          IconButton(
            icon: Icon(Icons.filter_alt),
            onPressed: () {},
          )
        ],
      ),
    );
  }
}
