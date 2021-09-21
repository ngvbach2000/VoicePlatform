import 'package:flutter/material.dart';
import 'package:voice_platform/screens/first_time_screen.dart';

import './screens/detail_actor_screen.dart';
import './screens/first_time_screen.dart';
import './screens/get_started1_screen.dart';
import './screens/get_started2_screen.dart';
import './screens/sign_up_screen.dart';
import './screens/main_screen.dart';
import 'constants/constants.dart';

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
        "/": (context) => const FirstTime(),
        "/get1": (context) => const GetStarted1(),
        "/get2": (context) => const GetStarted2(),
        "/signup": (context) => const SignUpScreen(),
        "/main": (context) => const MainScreen(),
        "/detail": (context) => const DetailActorScreen(),
      },
    );
  }
}
