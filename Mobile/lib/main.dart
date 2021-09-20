import 'package:flutter/material.dart';
import 'package:voice_platform/screens/detail_actor_screen.dart';
import './screens/main_screen.dart';

void main() {
  // SystemChrome.setPreferredOrientations([
  //   DeviceOrientation.portraitUp,
  //   DeviceOrientation.portraitUp,
  // ]);
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      theme: ThemeData(
        primarySwatch: Colors.blue,
        fontFamily: 'Montserrat',
      ),
      initialRoute: '/',
      routes: <String, WidgetBuilder>{
        "/": (context) => const MainScreen(),
        "/detail": (context) => const DetailActorScreen(),
      },
    );
  }
}
