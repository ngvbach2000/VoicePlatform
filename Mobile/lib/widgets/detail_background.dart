import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';

class DetailBackground extends StatelessWidget {
  final Widget child;

  const DetailBackground({
    Key? key,
    required this.child,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    Size size = MediaQuery.of(context).size;

    return SizedBox(
      width: double.infinity,
      height: size.height,
      child: Stack(
        alignment: Alignment.center,
        children: <Widget>[
          Positioned(
            top: 0,
            left: 0,
            child: SvgPicture.asset(
              "assets/images/top-circle-bg.svg",
              width: size.width * 0.35,
            ),
          ),
          Positioned(
            bottom: 0,
            right: 0,
            child: SvgPicture.asset(
              "assets/images/bot-circle-bg.svg",
              width: size.width * 0.4,
            ),
          ),
          child
        ],
      ),
    );
  }
}
