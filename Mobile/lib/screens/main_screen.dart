import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:voice_platform/models/voice_actor.dart';
import 'package:voice_platform/widgets/voice_actor_modal.dart';

class MainScreen extends StatefulWidget {
  const MainScreen({Key? key}) : super(key: key);

  @override
  _MainScreenState createState() => _MainScreenState();
}

class _MainScreenState extends State<MainScreen> {
  int _currentIndex = 0;
  List<VoiceActor> _actors = List.empty();

  Future<String> loadVoiceActorsFromAsset() async {
    return await rootBundle.loadString('assets/json/voiceActors.json');
  }

  Future loadVoiceActors() async {
    String jsonString = await loadVoiceActorsFromAsset();
    final jsonResponse = json.decode(jsonString);
    List<VoiceActor> _voiceActors = jsonResponse.map<VoiceActor>((j) => VoiceActor.fromJson(j)).toList();
    _actors = _voiceActors;
  }

  @override
  void initState() {
    super.initState();
    loadVoiceActors();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
        child: Column(
          children: <Widget>[for (VoiceActor actor in _actors) VoiceActorModal(voiceActor: actor, key: Key(actor.id))],
        ),
      ),
      bottomNavigationBar: BottomNavigationBar(
        currentIndex: _currentIndex,
        items: const [
          BottomNavigationBarItem(icon: Icon(Icons.home), label: 'Home', backgroundColor: Colors.amber),
          BottomNavigationBarItem(
              icon: Icon(Icons.account_balance_wallet), label: 'Wallet', backgroundColor: Colors.amber),
          BottomNavigationBarItem(icon: Icon(Icons.history), label: 'History', backgroundColor: Colors.amber),
          BottomNavigationBarItem(icon: Icon(Icons.assignment_ind), label: 'Profile', backgroundColor: Colors.amber),
        ],
        onTap: (index) {
          setState(() {
            _currentIndex = index;
          });
        },
      ),
    );
  }
}
