import 'package:flutter/material.dart';

class Badge extends StatelessWidget {
  final String text;
  final Color colorText;
  final Color colorBadge;

  const Badge({
    Key? key,
    required this.text,
    required this.colorText,
    required this.colorBadge,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: const EdgeInsets.symmetric(
        vertical: 9.0,
        horizontal: 15.0,
      ),
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(15.0),
        color: colorBadge,
      ),
      child: Text(
        text,
        textAlign: TextAlign.center,
        style: TextStyle(
          fontWeight: FontWeight.w600,
          color: colorText,
          fontSize: 12.0,
        ),
      ),
    );
  }
}
