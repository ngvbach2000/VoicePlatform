import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';

import '../constants/constants.dart';

import '../models/voice_actor.dart';

import '../widgets/search_actor_bar.dart';
import '../widgets/voice_actor_modal.dart';
import '../widgets/detail_background.dart';
import '../widgets/layout.dart';

class MainScreen extends StatefulWidget {
  const MainScreen({Key? key}) : super(key: key);

  @override
  _MainScreenState createState() => _MainScreenState();
}

class _MainScreenState extends State<MainScreen> {
  int _currentIndex = 0;
  List<VoiceActor> _actors = List.empty();
  static const inputFieldStyle = TextStyle(fontSize: 15, height: 0.5);

  Future<String> loadVoiceActorsFromAsset() async {
    return await rootBundle.loadString('assets/json/voiceActors.json');
  }

  Future loadVoiceActors() async {
    String jsonString = await loadVoiceActorsFromAsset();
    final jsonResponse = json.decode(jsonString);
    List<VoiceActor> _voiceActors =
        jsonResponse.map<VoiceActor>((j) => VoiceActor.fromJson(j)).toList();
    _actors = _voiceActors;
  }

  @override
  void initState() {
    super.initState();
    loadVoiceActors();
  }

  @override
  Widget build(BuildContext context) {
    Size size = MediaQuery.of(context).size;
    return Scaffold(
      body: DetailBackground(
        child: SingleChildScrollView(
          child: Layout(
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: <Widget>[
                SizedBox(
                  height: 75,
                ),
                Image.asset(
                  'assets/images/logo.png',
                  fit: BoxFit.cover,
                  scale: 4.0,
                ),
                const Text(
                  'Voice Platform',
                  style: TextStyle(
                    fontSize: 20,
                    fontWeight: FontWeight.normal,
                    fontFamily: 'Gugi',
                  ),
                ),
                const Text(
                  'Lorem ipsum dolor sit amet, consectetur adipiscing elit.',
                  style: TextStyle(
                    fontSize: 15,
                    fontWeight: FontWeight.normal,
                    fontFamily: 'Gugi',
                  ),
                  textAlign: TextAlign.center,
                ),
                Column(
                  children: <Widget>[
                    SizedBox(
                      height: 25,
                    ),
                    Container(
                      width: size.width,
                      child: Text(
                        'Hi team!',
                        style: TextStyle(fontWeight: FontWeight.bold, fontSize: 15),
                        textAlign: TextAlign.left,
                      ),
                    ),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.center,
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: <Widget>[
                        Container(
                          width: size.width * 0.75,
                          color: whitegray,
                          child: const TextField(
                            decoration: InputDecoration(
                              border: OutlineInputBorder(),
                              labelText: 'Search',
                            ),
                          ),
                        ),
                        Container(
                          child: IconButton(
                            icon: Icon(Icons.filter_alt),
                            onPressed: () {},
                          ),
                        ),
                      ],
                    ),
                  ],
                ),
                Container(
                  margin: EdgeInsets.fromLTRB(0, 25, 0, 0),
                  width: size.width,
                  child: const Text(
                    'Voice Actor.',
                    style: TextStyle(
                      fontSize: 15,
                      fontWeight: FontWeight.normal,
                      fontFamily: 'Gugi',
                    ),
                    textAlign: TextAlign.left,
                  ),
                ),
                for (VoiceActor actor in _actors)
                  VoiceActorModal(voiceActor: actor, key: Key(actor.id))
              ],
            ),
          ),
        ),
      ),
      // bottomNavigationBar: BottomNavigationBar(
      //   currentIndex: _currentIndex,
      //   items: const [
      //     BottomNavigationBarItem(
      //         icon: Icon(Icons.home),
      //         label: 'Home',
      //         backgroundColor: appDarkColor),
      //     BottomNavigationBarItem(
      //         icon: Icon(Icons.account_balance_wallet),
      //         label: 'Wallet',
      //         backgroundColor: appDarkColor),
      //     BottomNavigationBarItem(
      //         icon: Icon(Icons.history),
      //         label: 'History',
      //         backgroundColor: appDarkColor),
      //     BottomNavigationBarItem(
      //         icon: Icon(Icons.assignment_ind),
      //         label: 'Profile',
      //         backgroundColor: appDarkColor),
      //   ],
      //   onTap: (index) {
      //     setState(() {
      //       _currentIndex = index;
      //     });
      //   },
      // ),
      bottomNavigationBar: Theme(
        data: Theme.of(context).copyWith(
          // sets the background color of the BottomNavigationBar
            canvasColor: appYellowColor,
            // sets the active color of the BottomNavigationBar if Brightness is light
            primaryColor: appYellowColor,
            textTheme: Theme
                .of(context)
                .textTheme
                .copyWith(caption: new TextStyle(color: Colors.black))), // sets the inactive color of the BottomNavigationBar
        child: BottomNavigationBar(
          type: BottomNavigationBarType.fixed,
          currentIndex: 0,
          items: [
            BottomNavigationBarItem(
              icon: new Icon(Icons.home),
              title: new Text("Home"),
            ),
            BottomNavigationBarItem(
              icon: new Icon(Icons.account_balance_wallet),
              title: new Text("Wallet"),
            ),
            BottomNavigationBarItem(
              icon: new Icon(Icons.history),
              title: new Text("History"),
            ),
            BottomNavigationBarItem(
              icon: new Icon(Icons.assignment_ind),
              title: new Text("Profile"),
            )
          ],
        ),
      ),
    );
  }
}
